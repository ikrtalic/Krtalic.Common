using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Krtalic.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Return replacementValue when string is null
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="ReplacementValue"></param>
        /// <returns></returns>
        public static string WhenNull(this string Value, string ReplacementValue = "")
        {
            return Value == null ? ReplacementValue : Value;
        }

        /// <summary>
        /// Return replacementValue when string is null or empty
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="ReplacementValue"></param>
        /// <returns></returns>
        public static string WhenEmpty(this string Value, string ReplacementValue = "")
        {
            return string.IsNullOrWhiteSpace(Value) ? ReplacementValue : Value;
        }

        /// <summary>
        /// Concat a list of strings
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="AppendValues"></param>
        /// <returns></returns>
        public static string AppendEnumerable(this string Value, IEnumerable<string> AppendValues)
        {
            return AppendValues.Aggregate((previous, current) => previous + "; " + current);
        }

        /// <summary>
        /// Return the string with only letters and number, remove the rest
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="DefaultWhenEmpty">Return this when result of cleanup is empty string</param>
        /// <returns></returns>
        public static string EnsureLettersAndNumbers(this string Value, string DefaultWhenEmpty = "")
        {
            if (string.IsNullOrEmpty(Value)) return Value;

            var cleanValue = Regex.Replace(Value, @"[^0-9a-zA-Z]+", "");
            return string.IsNullOrWhiteSpace(cleanValue) ? DefaultWhenEmpty : cleanValue;
        }
    }
}
