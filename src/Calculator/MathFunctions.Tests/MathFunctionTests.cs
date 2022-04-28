using MathFunctions;
using System;
using Xunit;

namespace MathFunctionTests
{
    /// <summary>
    /// Tests for mathematical functions
    /// </summary>
    public class MathFunctionTests
    {
        public MathFunction mathFunctions;
        public MathFunctionTests()
        {
            mathFunctions = MathFunction.GetInstance();
        }

        /// <summary>
        /// Test for Sum function
        /// </summary>
        /// <param name="value1">Operand 1</param>
        /// <param name="value2">Operand 2</param>
        /// <param name="expected_result">Expected result of sum</param>
        [Theory]
        [InlineData(2F, 3F, 5F)]
        [InlineData(-10F, 5F, -5F)]
        [InlineData(1F, -0.5F, 0.5F)]
        [InlineData(-1F, -0.5F, -1.5F)]
        [InlineData(double.MaxValue, double.MinValue, 0)]
        [InlineData(double.MinValue, double.MaxValue, 0)]
        [InlineData(double.MaxValue, 0, double.MaxValue)]
        [InlineData(double.MinValue, 0, double.MinValue)]
        public void TestSum(double value1, double value2, double expected_result)
        {
            Assert.Equal(mathFunctions.Sum(value1, value2), expected_result);
        }

        /// <summary>
        /// Test for Substract function
        /// </summary>
        /// <param name="value1">Operand 1</param>
        /// <param name="value2">Operand 2</param>
        /// <param name="expected_result">Expected result of substraction</param>
        [Theory]
        [InlineData(5F, 3F, 2F)]
        [InlineData(-5F, 5F, -10F)]
        [InlineData(5F, -5F, 10F)]
        [InlineData(0.5F, -1.1F, 1.6F)]
        [InlineData(-0.5F, -1.1F, 0.6F)]
        [InlineData(double.MaxValue, -double.MinValue, 0)]
        [InlineData(double.MinValue, -double.MaxValue, 0)]
        [InlineData(double.MaxValue, 0, double.MaxValue)]
        [InlineData(double.MinValue, 0, double.MinValue)]
        public void TestSubstract(double value1, double value2, double expected_result)
        {
            Assert.Equal(mathFunctions.Substract(value1, value2), expected_result);
        }

        /// <summary>
        /// Test for Multiply function
        /// </summary>
        /// <param name="value1">Operand 1</param>
        /// <param name="value2">Operand 2</param>
        /// <param name="expected_result">Expected result of multiplication</param>
        [Theory]
        [InlineData(5F, 3F, 15F)]
        [InlineData(-5F, 5F, -25F)]
        [InlineData(5F, -5F, -25F)]
        [InlineData(0.5F, -2F, -1F)]
        [InlineData(-0.5F, -2F, 1F)]
        [InlineData(-0.5F, 0, 0)]
        [InlineData(double.MaxValue, 1, double.MaxValue)]
        [InlineData(1, double.MaxValue, double.MaxValue)]
        [InlineData(double.MaxValue, 0, 0)]
        [InlineData(double.MinValue, 1, double.MinValue)]
        [InlineData(double.MinValue, 0, 0)]
        public void TestMultiply(double value1, double value2, double expected_result)
        {
            Assert.Equal(mathFunctions.Multiply(value1, value2), expected_result);
        }
        /// <summary>
        /// Test for Division function
        /// </summary>
        /// <param name="value1">Operand 1</param>
        /// <param name="value2">Operand 2</param>
        /// <param name="expected_result">Expected result of division</param>
        [Theory]
        [InlineData(10F, 2F, 5F)]
        [InlineData(-5F, 5F, -1F)]
        [InlineData(2F, -5F, -0.4F)]
        [InlineData(-0.5F, -1F, 0.5F)]
        [InlineData(double.MaxValue, 1, double.MaxValue)]
        [InlineData(double.MinValue, 1, double.MinValue)]
        public void TestDivision(double value1, double value2, double expected_result)
        {
            Assert.Equal(mathFunctions.Divide(value1, value2), expected_result);
        }

        /// <summary>
        /// Test for Division by zero
        /// </summary>
        /// <param name="value1">Operand 1</param>
        /// <param name="value2">Operand 2</param>
        [Theory]
        [InlineData(10F, 0)]
        [InlineData(-0.5F, 0)]
        [InlineData(double.MaxValue, 0)]
        [InlineData(double.MinValue, 0)]
        public void TestDivisionByZero(double value1, double value2)
        {
            Assert.Throws<DivideByZeroException>(() => mathFunctions.Divide(value1, value2));
        }
        /// <summary>
        /// Test for Factorial function
        /// </summary>
        /// <param name="value1">Operand 1</param>
        /// <param name="expected_result">Expected result of factorial</param>
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(5, 120)]
        [InlineData(10, 3628800)]
        public void TestFactorial(int value1, double expected_result)
        {
            Assert.Equal(mathFunctions.Factorial(value1), expected_result);
        }
        /// <summary>
        /// Test for negative faktorial
        /// </summary>
        /// <param name="value1">Operand 1</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(int.MinValue)]
        public void TestFactorialNegative(int value1)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => mathFunctions.Factorial(value1));
        }

        /// <summary>
        /// Test for Power function
        /// </summary>
        /// <param name="value1">Operand 1</param>
        /// <param name="value2">Operand 2</param>
        /// <param name="expected_result">Expected result of power</param>
        [Theory]
        [InlineData(5F, 0, 1F)]
        [InlineData(10F, 1, 10F)]
        [InlineData(0.5, 2, 0.25F)]
        [InlineData(-0.5, 3, -0.125F)]
        [InlineData(-5F, 2, 25F)]
        [InlineData(-5F, 3, -125F)]
        [InlineData(1, int.MaxValue, 1)]
        [InlineData(double.MaxValue, 1, double.MaxValue)]
        [InlineData(double.MinValue, 1, double.MinValue)]
        [InlineData(double.MaxValue, 0, 1)]
        [InlineData(double.MinValue, 0, 1)]
        public void TestPower(double value1, int value2, double expected_result)
        {
            Assert.Equal(mathFunctions.Power(value1, value2), expected_result);
        }

        /// <summary>
        /// Test for negative power
        /// </summary>
        /// <param name="value1">Operand 1</param>
        /// <param name="value2">Operand 2</param>
        [Theory]
        [InlineData(10, -1)]
        [InlineData(3, -10)]
        [InlineData(5, int.MinValue)]
        public void TestPowerNegative(double value1, int value2)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => mathFunctions.Power(value1, value2));
        }

        /// <summary>
        /// Test for Root function
        /// </summary>
        /// <param name="value1">Operand 1</param>
        /// <param name="value2">Operand 2</param>
        /// <param name="expected_result">Expected result of root</param>
        [Theory]
        [InlineData(10F, 1, 10F)]
        [InlineData(25F, 2, 5F)]
        [InlineData(8F, 3, 2F)]
        [InlineData(-8F, 3, -2F)]
        [InlineData(-27F, 3, -3F)]
        [InlineData(27F, 3, 3F)]
        [InlineData(0.25F, 2, 0.5F)]
        [InlineData(-0.125F, 3, -0.5F)]
        [InlineData(-125F, 3, -5F)]
        [InlineData(125F, 3, 5F)]
        [InlineData(-1000000F, 3, -100F)]
        [InlineData(1000000F, 3, 100F)]
        [InlineData(1073741824F, 3, 1024F)]
        [InlineData(19683F, 9, 3F)]
        [InlineData(9765625F, 10, 5F)]
        [InlineData(double.MaxValue, 1, double.MaxValue)]
        [InlineData(double.MinValue, 1, double.MinValue)]
        [InlineData(1, int.MaxValue, 1)]
        public void TestRoot(double value1, int value2, double expected_result)
        {
            Assert.Equal(mathFunctions.Root(value1, value2), expected_result);
        }

        /// <summary>
        /// Test for negative root
        /// </summary>
        /// <param name="value1">Operand 1</param>
        /// <param name="value2">Operand 2</param>
        [Theory]
        [InlineData(1, 0)]
        [InlineData(10, -1)]
        [InlineData(3, -10)]
        [InlineData(5, int.MinValue)]
        public void TestRootNegative(double value1, int value2)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => mathFunctions.Root(value1, value2));
        }

        /// <summary>
        /// Test for Fibonacci sequence
        /// </summary>
        /// <param name="value1">Operand 1</param>
        /// <param name="expected_result">Expected result of fibonacci</param>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(10, 55)]
        [InlineData(20, 6765)]
        [InlineData(40, 102334155)]
        public void TestFibonacci(int value1, int expected_result)
        {
            Assert.Equal(mathFunctions.Fibbonacci(value1), expected_result);
        }

        /// <summary>
        /// Test for negative Fibonacci
        /// </summary>
        /// <param name="value1">Operand 1</param>
        [Theory]
        [InlineData(-3)]
        [InlineData(-3438965)]
        public void TestFibonacciNegative(int value1)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => mathFunctions.Fibbonacci(value1));
        }
    }
}
