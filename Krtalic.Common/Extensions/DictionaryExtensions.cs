using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krtalic.Common.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Create debug print string out of a dictionary
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="Dictionary"></param>
        /// <returns></returns>
        public static string ToDebugString<TKey, TValue>(this IDictionary<TKey, TValue> Dictionary)
        {
            return "{ " + string.Join(", ", Dictionary.Select(kv => kv.Key + "=" + kv.Value).ToArray()) + " }";
        }

        /// <summary>
        /// Merge two dictionaries
        /// Think this was picked from Stackoverflow...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="Self"></param>
        /// <param name="Others"></param>
        /// <returns></returns>
        public static T MergeLeft<T, K, V>(this T Self, params IDictionary<K, V>[] Others)
            where T : IDictionary<K, V>, new()
        {
            T newMap = new T();
            foreach (IDictionary<K, V> src in (new List<IDictionary<K, V>> { Self }).Concat(Others))
            {
                foreach (KeyValuePair<K, V> p in src)
                {
                    newMap[p.Key] = p.Value;
                }
            }
            return newMap;
        }
    }
}
