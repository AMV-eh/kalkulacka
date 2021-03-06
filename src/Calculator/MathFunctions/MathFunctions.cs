using System;

namespace MathFunctions
{
    /// <summary>
    /// Class containing math functions 
    /// Is based of Singleton design
    /// </summary>
    public class MathFunction
    {
        private static MathFunction instance = null;

        public static MathFunction GetInstance()
        {
            if (instance == null)
            {
                instance = new MathFunction();
            }
            return instance;
        }

        /// <summary>
        /// Calculates Summary of 2 numbers
        /// </summary>
        /// <param name="a">Operand 1</param>
        /// <param name="b">Operand 2</param>
        /// <returns>Sum of two numbers</param>
        public double Sum(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Function for substraction
        /// </summary>
        /// <param name="a">Operand 1</param>
        /// <param name="b">Operand 2</param>
        /// <returns>Substraction of two numbers</param>
        public double Substract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Function for multiplication
        /// </summary>
        /// <param name="a">Operand 1</param>
        /// <param name="b">Operand 2</param>
        /// <returns>Result of multiplication</param>
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Function for division
        /// </summary>
        /// <param name="a">Operand 1</param>
        /// <param name="b">Operand 2</param>
        /// <returns>Result of division</param>
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            return a / b;
        }

        /// <summary>
        /// Function for factorial
        /// </summary>
        /// <param name="a">Operand 1</param>
        /// <returns>Result of factorial</param>
        public int Factorial(int a)
        {
            if (a < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int result = 1;
            for (int i = 1; i <= a; i++)
            {
                result *= i;
            }
            return result;
        }

        /// <summary>
        /// Function for power
        /// </summary>
        /// <param name="a">Operand 1</param>
        /// <param name="b">Operand 2</param>
        /// <returns>A power on B</returns>
        public double Power(double a, int b)
        {
            double result = 1;
            if (b < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = 0; i < b; i++)
            {
                result *= a;
            }
            return result;
        }

        /// <summary>
        /// Function for root
        /// </summary>
        /// <param name="a">Operand 1</param>
        /// <param name="b">Operand 2</param>
        /// <returns>Result of b-th root</returns>
        public double Root(double a, int b)
        {
            if (b <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (a == 1)
            {
                return a;
            }


            // Calculate round coeficient
            int round_coeficient = 5;
            if (a > 1000 || a < -1000)
            {
                round_coeficient = 3;
            }
            else if (a > 100 || a < -100)
            {
                round_coeficient = 5;
            }


            // if b is even, its calculated normally
            if (b % 2 == 0 || a > 0)
            {
                // Rounding number to X digits to eliminate inaccuracy
                double result = Math.Pow(a, 1F / b);
                return (double)Math.Round(result, round_coeficient);
            }
            else
            {
                // if "b" is odd and "a" is negative, function Math.Pow() returns NaN instead of negative result
                // we use "-a" -> (negative "a") and calculate nth root of it, then return "-result" -> negative result

                // Rounding number to X digits to eliminate inaccuracy
                double result = -Math.Pow(-a, 1F / b);
                return (double)Math.Round(result, round_coeficient);
            }
        }

        /// <summary>
        /// Function for fibbonacci
        /// </summary>
        /// <param name="a">Operand 1</param>
        /// <returns>A-th fibbonacci sequence</returns>
        public double Fibbonacci(int a)
        {
            if (a < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (a == 0)
            {
                return 0;
            }
            if (a == 1 || a == 2)
            {
                return 1;
            }

            int first = 1;
            int second = 1;

            for (int i = 0; i < a - 2; i++)
            {
                first += second;
                int tmp = first;
                first = second;
                second = tmp;
            }

            return second;
        }
    }
}
