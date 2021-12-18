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
using TollCalculater.Hourfee;
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
        private readonly IHourfee hourfee;
        // Maxtollperday 60 SEK
        const int max_tollfee = 60;
        public  int GetTollFee(Vehicle vehicle, DateTime[] dates)
        {
            if (dates == null || dates.Length == 0)
            {
                throw new ArgumentException("!!oops No dates find");
            }

            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            if (!IsDuplicateDate(dates))
            {
                throw new ArgumentException("OOps!!Accept: Only  one date ");
            }

            //Delete lessthan Hour datetimes
            DateTime intervalStart = dates[0];
            int totalFee = GetTollFee(intervalStart, vehicle);
            foreach (DateTime date in dates)
            {
                int nextFee = GetTollFee(date, vehicle);
                //int tempFee = GetTollFee(intervalStart, vehicle);

                //long diffInMillies = date.Millisecond - intervalStart.Millisecond;
                long minutes = (date.Hour - intervalStart.Hour) * 60 + date.Minute - intervalStart.Minute;

                if (minutes <= 60)
                {
                    continue;
                }
                else
                {
                    totalFee += nextFee;
                    intervalStart = date;
                }
                if(max_tollfee <= totalFee) { return max_tollfee; }

            }
            //if (totalFee > 60) totalFee = 60;
            return totalFee;
        }
        private int GetTollFee(DateTime date, Vehicle vehicle)
        {
            return hourfee.GetHourlyFee(date, vehicle);
        }

        private static bool IsDuplicateDate(DateTime[] dates)
        {
            DateTime acceptdate = dates[0];
            return (dates.All(date => date.Year == acceptdate.Year &&
                                     date.Month == acceptdate.Month &&
                                     date.Day == acceptdate.Day));

        }

        //private IEnumerable<DateTime> F_dateSort(IEnumerable<DateTime> dates)
        //{
        //    return dates.OrderBy(date => date);
        //}




        // to access token for retrieving the information from  svenskahelgdagar.info website

        //private static bool IstollfeeFreeDate(DateTime date)
        //{
        //    //check weekend
        //    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || date.Month == 7) return true;
        //    // connecting website thrugh API
        //    var client_v = new HttpClient() { BaseAddress = new Uri("https://svenskahelgdagar.info/v2/") };
        //    client_v.DefaultRequestHeaders.Accept.Clear();
        //    client_v.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    var accessToken_info = GetAccessToken_tollfee(client_v).Result;

        //    client_v.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken_info);
        //    return IsPublicSunday(date, client_v).Result || IsPublicSunday(date.AddDays(1), client_v).Result;
        //    static async Task<string> GetAccessToken_tollfee(HttpClient client)
        //    {
        //        //get access token cetails 
        //        var client_Id = "jencyraj919961";
        //        var client_Secret = "f32872-d91cee-eb697d-4731e4-c14f3b";

        //        var postData = new List<KeyValuePair<string, string>>
        //            {
        //                new KeyValuePair<string, string>("grant_type", "client_credentials"),
        //                new KeyValuePair<string, string>("client_id", client_Id),
        //                new KeyValuePair<string, string>("client_secret", client_Secret)
        //            };

        //        var content = new FormUrlEncodedContent(postData);

        //        var response = await client.PostAsync("access_token", content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var jsonString = await response.Content.ReadAsStringAsync();
        //            dynamic responseData = JsonConvert.DeserializeObject(jsonString);
        //            return responseData?.access_token;
        //        }

        //        throw new HttpRequestException(response.StatusCode.ToString());
        //    }
        //    static async Task<bool> IsPublicSunday(DateTime dateTime, HttpClient httpClient)

        //    {

        //        var response = await httpClient.GetAsync($"date/{dateTime.ToShortDateString()}");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var jsonString = await response.Content.ReadAsStringAsync();
        //            dynamic responseData = JsonConvert.DeserializeObject(jsonString);
        //            return responseData?.response is JObject && (bool)responseData.response.public_sunday;
        //        }

        //        throw new HttpRequestException(response.StatusCode.ToString());

        //    }
        //}
    }
}
