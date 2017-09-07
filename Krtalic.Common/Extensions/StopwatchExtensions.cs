using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krtalic.Common.Extensions
{
    public static class StopwatchExtensions
    {
        public static long ElapsedNanoseconds(this Stopwatch Self)
        {
            double ticks = Self.ElapsedTicks;
            return (long)((ticks / Stopwatch.Frequency) * 1000000000);
        }

        public static long ElapsedMicroseconds(this Stopwatch Self)
        {
            double ticks = Self.ElapsedTicks;
            return (long)((ticks / Stopwatch.Frequency) * 1000000);
        }
    }
}
