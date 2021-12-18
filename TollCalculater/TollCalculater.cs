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
    public class TollCalculater
    {
        /**
   * Calculate the total toll fee for one day
   *
   * @param vehicle - the vehicle
   * @param dates   - date and time of all passes on one day
   * @return - the total toll fee for that day
   */
        private readonly IHourfee ihourfee;
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
            return ihourfee.GetHourlyTollFee(date, vehicle);
        }

        private static bool IsDuplicateDate(DateTime[] dates)
        {
            DateTime acceptdate = dates[0];
            return (dates.All(date => date.Year == acceptdate.Year &&
                                     date.Month == acceptdate.Month &&
                                     date.Day == acceptdate.Day));

        }

        
    }
}
