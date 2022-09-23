using CalculatorLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Add_Positive_One_And_Positive_One_Correctly_And_Return_A_Doubles()
        {
            var result = Calculator.Add(1, 1);
            Assert.AreEqual(2, result);
            Assert.IsInstanceOfType(result, typeof(double));
        }

        [TestMethod]
        public void Add_Positive_2_Point_1_And_Positive_1_Point_1_And_Return_A_Double()
        {
            var result = Calculator.Add(2.1, 1.1);
            Assert.AreEqual(3.2, result);
            Assert.IsInstanceOfType(result, typeof(double), "This type is not type double.");
        }

        [TestMethod]
        [DataRow(1,1,2)]
        [DataRow(2.1, 1.1, 3.2)]
        [DataRow(2.2, 3.2, 5.4)]
        [DynamicData(nameof(GetPositiveNumbersToAdd), DynamicDataSourceType.Method)]
        public void Add_Any_2_Positive_Numbers_And_Return_A_Double(double left, double right, double expected)
        {
            var result = Calculator.Add(left, right);
            Assert.IsTrue(left > 0);
            Assert.IsTrue(right > 0);
            Assert.AreEqual(expected, result, $"{left} + {right} = {expected}");
            Assert.IsInstanceOfType(result, typeof(double));
        }

        private static IEnumerable<Object[]> GetPositiveNumbersToAdd()
        {
            var list = new List<Object[]>();

            for (int i = 0; i < 10000; i++)
            {
                Random random = new Random();
                var left = random.NextDouble() * random.NextInt64();
                var right = random.NextDouble() * random.NextInt64();
                var expected = left + right;

                if (expected > 0)
                {
                    list.Add(new Object[] { left, right, expected });
                }
                else
                {
                    i--;
                }
                    
            }

            return list;
        }
    }
}