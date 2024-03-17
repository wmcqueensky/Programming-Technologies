using Calculator;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void TestAdd()
        {
            double num1 = 5;
            double num2 = 3;

            double result = Add.Perform(num1, num2);

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void TestSubtract()
        {
            double num1 = 5;
            double num2 = 3;

            double result = Subtract.Perform(num1, num2);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestMultiply()
        {
            double num1 = 5;
            double num2 = 3;

            double result = Multiply.Perform(num1, num2);

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void TestDivide()
        {
            double num1 = 6;
            double num2 = 3;

            double result = Divide.Perform(num1, num2);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestDivideByZero()
        {
            double num1 = 6;
            double num2 = 0;

            Assert.ThrowsException<ArgumentException>(() => Divide.Perform(num1, num2));
        }
    }
}
