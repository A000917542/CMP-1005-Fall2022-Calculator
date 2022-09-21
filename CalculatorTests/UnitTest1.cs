using CalculatorLogic;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Add_Two_Positive_Integers()
        {
            int result = Calculator.Add(1, 1);
            Assert.AreEqual(2, result);
        }
    }
}