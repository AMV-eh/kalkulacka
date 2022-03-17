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
    }
}
