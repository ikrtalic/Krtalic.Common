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
    public class DictionaryExtensionsTests
    {
        private Dictionary<int, string> _TestData;

        [TestInitialize]
        public void Init()
        {
            _TestData = new Dictionary<int, string>
            {
                { 1, "One" },
                { 2, "Two" },
                { 3, "Three" },
                { 4, "Four" },
                { 5, "Five" },
            };
        }

        [TestMethod]
        public void MergedDictionaryHasSevenEntries()
        {
            var merged = _TestData.MergeLeft(new Dictionary<int, string>
                {
                    { 6, "Six" },
                    { 7, "Seven" }
                });
            Assert.AreEqual(merged.Count, 7);
        }

        [TestMethod]
        public void DuplicateValuesDoNotThrowException()
        {
            var merged = _TestData.MergeLeft(new Dictionary<int, string>
                {
                    { 6, "Six" },
                    { 5, "Five" }
                });
            Assert.AreEqual(merged.Count, 6);
        }
    }
}
