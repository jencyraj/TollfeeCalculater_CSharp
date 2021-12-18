using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TollCalculater.VehicleList;
namespace TollCalculater
{
    public static class TollCalculater
    {
        /**
   * Calculate the total toll fee for one day
   *
   * @param vehicle - the vehicle
   * @param dates   - date and time of all passes on one day
   * @return - the total toll fee for that day
   */
        public static int GetTollFee(CVehicle vehicle, DateTime[] dates)
        {
            if (vehicle.TollFree())
            {
                return 0;
            }
            Array.Sort(dates);
            var total_tollfee = 0;
            var total_tollfeeDay = 0;
            var highest_tollfee = 0;
            var intervalStart = dates[0];
            //var date = 0;
            foreach (var date in dates)
            {
                if (date.Date != intervalStart.Date)
                {
                    total_tollfee = total_tollfeeDay + 1;
                    total_tollfeeDay = 0;
                }
                var toll_fee = GetTollFee(date);
                if (date < intervalStart.AddHours(1))
                {
                    if (toll_fee > highest_tollfee) { highest_tollfee = toll_fee; }
                }
                else
                {
                    intervalStart = date;
                    total_tollfeeDay += highest_tollfee + toll_fee;
                    if (total_tollfeeDay > 60) { total_tollfeeDay = 60; }
                    highest_tollfee = 0;
                }

            }
            if (highest_tollfee > 0) { total_tollfeeDay = highest_tollfee; }

            return total_tollfee + total_tollfeeDay;

        }

        private static int GetTollFee(DateTime date)
        {
            if (IstollfeeFreeDate(date))
                return 0;

            if (TimeBetween(date, (6, 0), (6, 29))) return 9;
            if (TimeBetween(date, (6, 30), (6, 59))) return 16;
            if (TimeBetween(date, (7, 0), (7, 59))) return 22;
            if (TimeBetween(date, (8, 0), (8, 29))) return 16;
            if (TimeBetween(date, (8, 30), (14, 59))) return 9;
            if (TimeBetween(date, (15, 00), (15, 29))) return 16;
            if (TimeBetween(date, (15, 30), (16, 59))) return 22;
            if (TimeBetween(date, (17, 00), (17, 59))) return 16;
            if (TimeBetween(date, (18, 00), (18, 29))) return 9;

            else

                return 0;
        }

        private static bool TimeBetween(DateTime passageTime, (int Hour, int Minute) startTime, (int Hour, int Minute) endTime)
        {
            var now = passageTime.TimeOfDay;
            var start = new TimeSpan(startTime.Hour, startTime.Minute, 0);
            var end = new TimeSpan(endTime.Hour, endTime.Minute, 59);

            return (now >= start) && (now <= end);
        }
        // to access token for retrieving the information from  svenskahelgdagar.info website

        private static bool IstollfeeFreeDate(DateTime date)
        {
            //check weekend
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || date.Month == 7) return true;
            // connecting website thrugh API
            var client_v = new HttpClient() { BaseAddress = new Uri("https://svenskahelgdagar.info/v2/") };
            client_v.DefaultRequestHeaders.Accept.Clear();
            client_v.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var accessToken_info = GetAccessToken_tollfee(client_v).Result;

            client_v.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken_info);
            return IsPublicSunday(date, client_v).Result || IsPublicSunday(date.AddDays(1), client_v).Result;
            static async Task<string> GetAccessToken_tollfee(HttpClient client)
            {
                //get access token cetails 
                var client_Id = "jencyraj919961";
                var client_Secret = "f32872-d91cee-eb697d-4731e4-c14f3b";

                var postData = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("grant_type", "client_credentials"),
                        new KeyValuePair<string, string>("client_id", client_Id),
                        new KeyValuePair<string, string>("client_secret", client_Secret)
                    };

                var content = new FormUrlEncodedContent(postData);

                var response = await client.PostAsync("access_token", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    dynamic responseData = JsonConvert.DeserializeObject(jsonString);
                    return responseData?.access_token;
                }

                throw new HttpRequestException(response.StatusCode.ToString());
            }
            static async Task<bool> IsPublicSunday(DateTime dateTime, HttpClient httpClient)

            {

                var response = await httpClient.GetAsync($"date/{dateTime.ToShortDateString()}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    dynamic responseData = JsonConvert.DeserializeObject(jsonString);
                    return responseData?.response is JObject && (bool)responseData.response.public_sunday;
                }

                throw new HttpRequestException(response.StatusCode.ToString());

            }
        }
    }
}
