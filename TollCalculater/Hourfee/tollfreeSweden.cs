using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollCalculater.VehicleList;

namespace TollCalculater.Hourfee
{
    public class tollfreeSweden : ItollFreeDays
    {
        public bool IsTollfree(DateTime date)
        {
            return Isweekenddays(date) || IsPublicHolyday(date);

        }

        private bool IsPublicHolyday(DateTime date)
        {
            return (date.Month == 1 && date.Day == 1 ||   //Newyear
                    date.Month == 1 && date.Day == 6 ||  //Epiphany day
                    date.Month == 5 && date.Day == 1 || // May first
                    date.Month == 6 && date.Day == 6 || // sweden national day
                    date.Month == 12 && date.Day == 24 || // x-mas holidays
                    date.Month == 12 && date.Day == 25 ||
                    date.Month == 12 && date.Day == 26 ||
                    easter_Holiday(date));

        }

        private bool easter_Holiday(DateTime date)
        {
            // TODO calculate easter holidays
            DateTime easterDays = GetEasterDays(date.Year);
            DateTime good_Friday = easterDays.AddDays(-2);
            DateTime ascensionDay = easterDays.AddDays(39);
            DateTime aftereastr = easterDays.AddDays(1);
            return (date.Month == good_Friday.Month && date.Day == good_Friday.Day ||
                    date.Month == ascensionDay.Month && date.Day == ascensionDay.Day ||
                    date.Month == aftereastr.Month && date.Day == aftereastr.Day);
        }

        private static DateTime GetEasterDays(int year)
        {
            // Todo calculate eater year,month, date
            int day = 0;
            int month = 0;

            int g = year % 19;
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day);
        }

        private bool Isweekenddays(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
