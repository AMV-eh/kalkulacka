using Calculator.Models;
using MathFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public static class OperationHelper
    {
        private static MathFunction MathFunction = MathFunction.GetInstance();

        public static string GetResult(OperationEnum operation, float operand1, float? operand2 = null)
        {
            float op2 = 0;

            if (operation != OperationEnum.Factorial && operation != OperationEnum.Fibonnacci)
            {
                op2 = (float)operand2;
            }
            else
            {
                if (operand2 == null)
                {
                    return null;
                }
            }

            switch (operation)
            {
                case OperationEnum.Sum:
                    return MathFunction.Sum(operand1, op2).ToString();
                case OperationEnum.Substract:
                    return MathFunction.Substract(operand1, op2).ToString();
                case OperationEnum.Multiply:
                    return MathFunction.Multiply(operand1, op2).ToString();
                case OperationEnum.Divide:
                    return MathFunction.Divide(operand1, op2).ToString();
                case OperationEnum.Factorial:
                    return MathFunction.Factorial((int)operand1).ToString();
                case OperationEnum.Power:
                    return MathFunction.Power(operand1, (int)op2).ToString();
                case OperationEnum.Root:
                    return MathFunction.Root(operand1, (int)op2).ToString();
                case OperationEnum.Fibonnacci:
                    //return MathFunction.Fibonnacci(operand1, op2).ToString();
                    break;
            }

            return null;
        }
    }
}
