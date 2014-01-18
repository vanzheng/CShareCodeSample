using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MySample
{
    [TestFixture]
    public class TestSearch
    {
        [Test]
        public void TestLargest() 
        {
            Assert.AreEqual(9, Search.Largest(new int[] { 7, 8, 9 }));
            Assert.AreEqual(9, Search.Largest(new int[] { 8, 7, 9 }));
            Assert.AreEqual(9, Search.Largest(new int[] { 9, 7, 8 }));
        }

        [Test]
        public void TestLargestOf4() 
        {
            Assert.AreEqual(9, Search.Largest(new int[] { 9, 8, 7, 9 }));
            Assert.AreEqual(10, Search.Largest(new int[] { 5, 6, 9, 10 }));
            Assert.AreEqual(20, Search.Largest(new int[] { 12, 13, 20, 16 }));
        }

        [Test]
        public void TestLargestOne() 
        {
            Assert.AreEqual(1, Search.Largest(new int[]{1}));
        }

        [Test]
        public void TestLargestNegative() 
        {
            Assert.AreEqual(-7, Search.Largest(new int[] { -8, -9, -7 }));
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void TestLargestEmpty() 
        {
            Search.Largest(new int[] { });
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void TestLargestNull() 
        {
            Search.Largest(null);
        }
    }
}
