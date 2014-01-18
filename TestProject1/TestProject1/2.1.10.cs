using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testDoNet.DataFunction;

namespace TestProject1
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
            string expected = "用户总额A和消费额B必须都为正整数或小数点后小于两位的小数";
            string actual = func.getSurplusMoney("a", "1");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            testFunction func = new testFunction();
            string expected = "用户总额A和消费额B必须都为正整数或小数点后小于两位的小数";
            string actual = func.getSurplusMoney("1", "a");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            testFunction func = new testFunction();
            string expected = "用户总额A和消费额B必须都为正整数或小数点后小于两位的小数";
            string actual = func.getSurplusMoney("a", "b");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            testFunction func = new testFunction();
            string expected = "用户总额A和消费额B必须都为正整数或小数点后小于两位的小数";
            string actual = func.getSurplusMoney("5.101", "1.101");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            testFunction func = new testFunction();
            string expected = "用户总额A和消费额B必须都为正整数或小数点后小于两位的小数";
            string actual = func.getSurplusMoney("-10", "0");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod6()
        {
            testFunction func = new testFunction();
            string expected = "用户总额A和消费额B必须都为正整数或小数点后小于两位的小数";
            string actual = func.getSurplusMoney("1", "-10");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod7()
        {
            testFunction func = new testFunction();
            string expected = "用户总额A和消费额B必须都为正整数或小数点后小于两位的小数";
            string actual = func.getSurplusMoney("5.101", "1");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod8()
        {
            testFunction func = new testFunction();
            string expected = "用户总额A和消费额B必须都为正整数或小数点后小于两位的小数";
            string actual = func.getSurplusMoney("１０", "５");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod9()
        {
            testFunction func = new testFunction();
            string expected = "总额和消费额均不能为零";
            string actual = func.getSurplusMoney("0", "0");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod10()
        {
            testFunction func = new testFunction();
            string expected = "不用找零，用户总额和消费额相等。";
            string actual = func.getSurplusMoney("5", "5");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod11()
        {
            testFunction func = new testFunction();
            string expected = "硬币最少个数→应找余额: 一元的硬币:1个 一角的硬币:1个";
            string actual = func.getSurplusMoney("5.1", "4");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod12()
        {
            testFunction func = new testFunction();
            string expected = "硬币最少个数→应找余额: 五角的硬币:1个 一角的硬币:2个";
            string actual = func.getSurplusMoney("5.2", "4.5");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod13()
        {
            testFunction func = new testFunction();
            string expected = "硬币最少个数→应找余额: 一角的硬币:1个";
            string actual = func.getSurplusMoney("5", "4.9");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod14()
        {
            testFunction func = new testFunction();
            string expected = "硬币最少个数→应找余额: 一元的硬币:4个 五角的硬币:1个 一角的硬币:2个";
            string actual = func.getSurplusMoney("8.6", "3.9");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod15()
        {
            testFunction func = new testFunction();
            string expected = "硬币最少个数→应找余额: 一元的硬币:3个 五角的硬币:1个 一角的硬币:2个";
            string actual = func.getSurplusMoney("7.1", "3.4");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod16()
        {
            testFunction func = new testFunction();
            string expected = "硬币最少个数→应找余额: 一元的硬币:3个 一角的硬币:3个";
            string actual = func.getSurplusMoney("10.1", "6.8");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod17()
        {
            testFunction func = new testFunction();
            string expected = "硬币最少个数→应找余额: 一角角的硬币:3个";
            string actual = func.getSurplusMoney("6.5", "6.2");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod18()
        {
            testFunction func = new testFunction();
            string expected = "抱歉，消费额超出总额，请追加总额。";
            string actual = func.getSurplusMoney("10", "10.1");
            Assert.AreEqual(expected, actual);
        }
    }
}
