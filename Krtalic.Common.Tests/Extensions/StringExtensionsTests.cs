using Krtalic.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krtalic.Common.Tests.Extensions
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void AppendReturnsProperString()
        {
            var array = new string[] { "1", "2", "3" };
            var start = "Number list: ";
            var appended = start.AppendEnumerable(array);
            Assert.AreEqual("1; 2; 3", appended);
        }
    }
}
