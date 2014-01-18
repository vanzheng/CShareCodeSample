using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testDoNet.DataFunction;

namespace TestProject2
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("a0010101");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("1000a101");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("100001a1");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("100a0101");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("100001011");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod6()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod7()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("01000101");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod8()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("10000101");
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod9()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate(null);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod10()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("１０００0101");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod11()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("1000０１01");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod12()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("100001０１");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod13()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("10000229");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod14()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("10000228");
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod15()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("1000-01-31");
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod16()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("1000-01-32");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod17()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("1000-12-01");
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod18()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("1000-12-00");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod19()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("1000-13-06");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod20()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("1000/01(01");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod21()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("1000*01/01");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod22()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("1000/02/15");
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod23()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("1000/2/1");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod24()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("1000/02/9");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod25()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("2000/02/29");
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod26()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("2000/02/30");
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod27()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("2008/04/31");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod28()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("2008/08/31");
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod29()
        {
            testFunction func = new testFunction();
            bool actual = func.chkDate("2008/02/29");
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }
    }
}
