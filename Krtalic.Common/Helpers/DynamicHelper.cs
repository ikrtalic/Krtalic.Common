using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krtalic.Common.Helpers
{
    public static class DynamicHelper
    {
        /// <summary>
        /// Returns a property value from an object
        /// </summary>
        /// <typeparam name="T">Type of property</typeparam>
        /// <param name="Target"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(object Target, string Name)
        {
            var site = System.Runtime.CompilerServices.CallSite<Func<System.Runtime.CompilerServices.CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(0, Name, Target.GetType(), new[] { Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo.Create(0, null) }));
            var obj = site.Target(site, Target);
            if (obj == null)
            {
                return default(T);
            }
            else
            {
                return (T)Convert.ChangeType(obj, typeof(T));
            }
        }

        public static bool ObjectContainsProperty(dynamic Object, string Property)
        {
            Type t = Object.GetType();
            return t.GetProperties().Any(p => p.Name.Equals(Property));
        }
    }
}
