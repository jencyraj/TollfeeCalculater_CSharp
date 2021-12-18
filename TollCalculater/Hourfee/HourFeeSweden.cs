using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollCalculater.VehicleList;

namespace TollCalculater.Hourfee
{
    public class HourFeeSweden : IHourfee

    {
        private readonly ItollFreeDays itollFreeDays;
        private readonly ItollFreeVehicleType itollFreeVehicleType;

        public int GetHourlyFee(DateTime date, Vehicle vehicle)
        {
            if (itollFreeDays.Istollfree(date) || itollFreeVehicleType.IsTollfree(vehicle.VehicleType)) return 0;
            if (TimeBetween(date, (6, 0), (6, 29))) return 9;
            if (TimeBetween(date, (6, 30), (6, 59))) return 16;
            if (TimeBetween(date, (7, 0), (7, 59))) return 22;
            if (TimeBetween(date, (8, 0), (8, 29))) return 16;
            if (TimeBetween(date, (8, 30), (14, 59))) return 9;
            if (TimeBetween(date, (15, 00), (15, 29))) return 16;
            if (TimeBetween(date, (15, 30), (16, 59))) return 22;
            if (TimeBetween(date, (17, 00), (17, 59))) return 16;
            if (TimeBetween(date, (18, 00), (18, 29))) return 9;

            return 0;

        }
        private static bool TimeBetween(DateTime passageTime, (int Hour, int Minute) startTime, (int Hour, int Minute) endTime)
        {
            var now = passageTime.TimeOfDay;
            var start = new TimeSpan(startTime.Hour, startTime.Minute, 0);
            var end = new TimeSpan(endTime.Hour, endTime.Minute, 59);

            return (now >= start) && (now <= end);
        }
    }
}
