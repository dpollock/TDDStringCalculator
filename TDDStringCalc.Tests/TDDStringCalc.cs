using System;
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
            var result = calculator.Add(string.Empty);

            Assert.AreEqual(0,result);

        }

        [TestMethod]
        public void OneNumberString()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("5");

            Assert.AreEqual(5, result);

        }

        [TestMethod]
        public void TwoNumberString()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("5,3");

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void HandlesNewLineAndCommaDelimiterString()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("5,3\n4");

            Assert.AreEqual(12, result);
        }



        [TestMethod]
        public void HandlesCommentedFirstLine()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

    }
}
