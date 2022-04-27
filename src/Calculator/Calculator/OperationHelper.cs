using Calculator.Models;
using MathFunctions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Calculator
{
    public static class OperationHelper
    {
        private static MathFunction MathFunction = MathFunction.GetInstance();

        public static string GetResult(OperationEnum operation, double operand1, double? operand2 = null)
        {
            double op2 = 0;

            if (operation != OperationEnum.Factorial && operation != OperationEnum.Fibonnacci)
            {
                op2 = (double)operand2;
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
                case OperationEnum.Subtract:
                    return MathFunction.Substract(operand1, op2).ToString();
                case OperationEnum.Multiply:
                    return MathFunction.Multiply(operand1, op2).ToString();
                case OperationEnum.Divide:
                    if (op2 == 0)
                    {
                        MessageBox.Show("Nulou dělit nelze!");
                        break;
                    }
                    else { 
                        return MathFunction.Divide(operand1, op2).ToString();
                    }
                case OperationEnum.Factorial:
                    return MathFunction.Factorial((int)operand1).ToString();
                case OperationEnum.Power:
                    if (op2 < 0)
                    {
                        MessageBox.Show("Musí být přirozené číslo!");
                        break;
                    }
                    else
                    {
                        return MathFunction.Power(operand1, (int)op2).ToString();
                    }
                case OperationEnum.Root:
                    if(op2 <= 0)
                    {
                        MessageBox.Show("Musí být číslo větší než 0!");
                        break;
                    }
                    else if ((op2 % 2 == 0) && (operand1 < 0))
                    {
                        MessageBox.Show("Nelze provést operaci!");
                        break;
                    }
                    else
                    {
                        return MathFunction.Root(operand1, (int)op2).ToString();
                    }
                    
                case OperationEnum.Fibonnacci:
                    return MathFunction.Fibbonacci((int)operand1).ToString();
            }

            return null;
        }
    }
}
