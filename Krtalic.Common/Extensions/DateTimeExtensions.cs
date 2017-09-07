using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krtalic.Common.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns date of the next day of the week from given date
        /// </summary>
        /// <param name="From"></param>
        /// <param name="DayOfWeek"></param>
        /// <returns></returns>
        public static DateTime Next(this DateTime From, DayOfWeek DayOfWeek)
        {
            int start = (int)From.DayOfWeek;
            int target = (int)DayOfWeek;
            if (target <= start)
                target += 7;
            return From.AddDays(target - start);
        }
    }
}
