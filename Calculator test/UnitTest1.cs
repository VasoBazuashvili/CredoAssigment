using NUnit.Framework;
using Calculator2;

namespace Calculator_test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, 2, 4)]
        [TestCase(0, 0, 1)]
        [TestCase(12, 7, 20)]
        public void ShouldSumTwoNumbers(double a, double b, double expectedValue)
        {
            var calc = new Calculator();
            var result = calc.Add(a, b);
            Assert.AreEqual(expectedValue, result);
        }
        [TestCase(4, 2, 2)]
        [TestCase(10, 5, 2)]
        [TestCase(10, 3, 3.333)]
        [TestCase(10, 0, 0)]
        public void ShouldDivideNumbers(double a, double b, double expectedValue)
        {
            var calc = new Calculator();
            var result = calc.Divide(a, b);
            Assert.AreEqual(expectedValue, result, 0.001);
        }
    }
}