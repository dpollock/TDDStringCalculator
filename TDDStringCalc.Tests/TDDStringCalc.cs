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

    }
}
