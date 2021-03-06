﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDStringCalc.Tests
{
    [TestClass]
    public class TDDStringCalc
    {
        [TestMethod]
        public void EmptyStringReturns0()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add(string.Empty);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void OneNumberString()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("5");

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TwoNumberString()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("5,3");

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void HandlesNewLineAndCommaDelimiterString()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("5,3\n4");

            Assert.AreEqual(12, result);
        }


        [TestMethod]
        public void HandlesCommentedFirstLine()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NegativeThrowsException()
        {
            try
            {
                var calculator = new StringCalculator();
                int result = calculator.Add("-5,4,-2");
                Assert.Fail("Didn't Catch negative numbers!");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Negative numbers not Allowed: -5 -2", ex.Message);
            }
        }


        [TestMethod]
        public void DoesntAddNumbersLargerThan1000()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("5,1005,10,67000");

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void DelimiterWrappedwithBrackets()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("//[***]\n1***2***3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void DelimiterMultipleBrackets()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("//[***][$$]\n1***2$$3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void DelimiterMultipleBracketsScenerio2()
        {
            var calculator = new StringCalculator();
            int result = calculator.Add("//[*][%]\n1*2%3");

            Assert.AreEqual(6, result);
        }
    }
}