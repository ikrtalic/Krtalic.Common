using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krtalic.Common.Extensions
{
    public static class StringListExtensions
    {
        public static string Flatten(this List<string> Self)
        {
            return string.Join(Environment.NewLine, Self);
        }
    }
}
