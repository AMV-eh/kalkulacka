using MathFunctions;
using System;
using Xunit;

namespace MathFunctionTests
{
    public class MathFunctionTests
    {
        public MathFunction mathFunctions;
        public MathFunctionTests()
        {
            mathFunctions = MathFunction.GetInstance();
        }


        // Test for Sum function
        [Theory]
        [InlineData(2F, 3F, 5F)]
        [InlineData(-10F, 5F, -5F)]
        [InlineData(1F, -0.5F, 0.5F)]
        [InlineData(-1F, -0.5F, -1.5F)]
        [InlineData(float.MaxValue, float.MinValue, 0)]
        [InlineData(float.MinValue, float.MaxValue, 0)]
        [InlineData(float.MaxValue, 0, float.MaxValue)]
        [InlineData(float.MinValue, 0, float.MinValue)]
        public void TestSum(float value1, float value2, float expected_result)
        {
            Assert.Equal(mathFunctions.Sum(value1, value2), expected_result);
        }

        // Test for Substract function
        [Theory]
        [InlineData(5F, 3F, 2F)]
        [InlineData(-5F, 5F, -10F)]
        [InlineData(5F, -5F, 10F)]
        [InlineData(0.5F, -1.1F, 1.6F)]
        [InlineData(-0.5F, -1.1F, 0.6F)]
        [InlineData(float.MaxValue, -float.MinValue, 0)]
        [InlineData(float.MinValue, -float.MaxValue, 0)]
        [InlineData(float.MaxValue, 0, float.MaxValue)]
        [InlineData(float.MinValue, 0, float.MinValue)]
        public void TestSubstract(float value1, float value2, float expected_result)
        {
            Assert.Equal(mathFunctions.Substract(value1, value2), expected_result);
        }

        // Test for Multiply function
        [Theory]
        [InlineData(5F, 3F, 15F)]
        [InlineData(-5F, 5F, -25F)]
        [InlineData(5F, -5F, -25F)]
        [InlineData(0.5F, -2F, -1F)]
        [InlineData(-0.5F, -2F, 1F)]
        [InlineData(-0.5F, 0, 0)]
        [InlineData(float.MaxValue, 1, float.MaxValue)]
        [InlineData(1, float.MaxValue, float.MaxValue)]
        [InlineData(float.MaxValue, 0, 0)]
        [InlineData(float.MinValue, 1, float.MinValue)]
        [InlineData(float.MinValue, 0, 0)]
        public void TestMultiply(float value1, float value2, float expected_result)
        {
            Assert.Equal(mathFunctions.Multiply(value1, value2), expected_result);
        }

        // Test for Division function
        [Theory]
        [InlineData(10F, 2F, 5F)]
        [InlineData(-5F, 5F, -1F)]
        [InlineData(2F, -5F, -0.4F)]
        [InlineData(-0.5F, -1F, 0.5F)]
        [InlineData(float.MaxValue, 1, float.MaxValue)]
        [InlineData(float.MinValue, 1, float.MinValue)]
        public void TestDivision(float value1, float value2, float expected_result)
        {
            Assert.Equal(mathFunctions.Divide(value1, value2), expected_result);
        }

        // Test for Division by zero function
        [Theory]
        [InlineData(10F, 0)]
        [InlineData(-0.5F, 0)]
        [InlineData(float.MaxValue, 0)]
        [InlineData(float.MinValue, 0)]
        public void TestDivisionByZero(float value1, float value2)
        {
            Assert.Throws<DivideByZeroException>(() => mathFunctions.Divide(value1, value2));
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(5, 120)]
        [InlineData(10, 3628800)]
        public void TestFactorial(int value1, float expected_result)
        {
            Assert.Equal(mathFunctions.Factorial(value1), expected_result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(int.MinValue)]
        public void TestFactorialNegative(int value1)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => mathFunctions.Factorial(value1));
        }

        
        [Theory]
        [InlineData(5F, 0, 1F)]
        [InlineData(10F, 1, 10F)]
        [InlineData(0.5, 2, 0.25F)]
        [InlineData(-0.5, 3, -0.125F)]
        [InlineData(-5F, 2, 25F)]
        [InlineData(-5F, 3, -125F)]
        [InlineData(1, int.MaxValue, 1)]
        [InlineData(float.MaxValue, 1, float.MaxValue)]
        [InlineData(float.MinValue, 1, float.MinValue)]
        [InlineData(float.MaxValue, 0, 1)]
        [InlineData(float.MinValue, 0, 1)]
        public void TestPower(float value1, int value2, float expected_result)
        {
            Assert.Equal(mathFunctions.Power(value1, value2), expected_result);
        }

        [Theory]
        [InlineData(10, -1)]
        [InlineData(3, -10)]
        [InlineData(5, int.MinValue)]
        public void TestPowerNegative(float value1, int value2)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => mathFunctions.Power(value1, value2));
        }

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
        [InlineData(float.MaxValue, 1, float.MaxValue)]
        [InlineData(float.MinValue, 1, float.MinValue)]
        [InlineData(1, int.MaxValue, 1)]
        public void TestRoot(float value1, int value2, float expected_result)
        {
            Assert.Equal(mathFunctions.Root(value1, value2), expected_result);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(10, -1)]
        [InlineData(3, -10)]
        [InlineData(5, int.MinValue)]
        public void TestRootNegative(float value1, int value2)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => mathFunctions.Root(value1, value2));
        }

        // TODO: create one more math function
    }
}
