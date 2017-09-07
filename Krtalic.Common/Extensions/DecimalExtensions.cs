using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krtalic.Common.Extensions
{
    /// <summary>
    /// Lazy extensions
    /// </summary>
    public static class DecimalExtensions
    {
        /// <summary>
        /// 123456.789 => 123000.0
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static decimal RoundToThousands(this decimal Value)
        {
            return Math.Floor(Value / 1000) * 1000;
        }

        public static decimal RoundTo2Digits(this decimal Value)
        {
            return Math.Round(Value, 2);
        }

        public static decimal RoundTo4Digits(this decimal Value)
        {
            return Math.Round(Value, 4);
        }
    }
}
