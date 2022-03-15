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
        [InlineData(-0.5F, 1F, 0.5F)]
        [InlineData(float.MaxValue, float.MinValue, 0)]
        [InlineData(float.MinValue, float.MaxValue, 0)]
        public void TestSum(float value1, float value2, float expected_result)
        {
            Assert.Equal(mathFunctions.Sum(value1, value2), expected_result);
        }
    }
}
