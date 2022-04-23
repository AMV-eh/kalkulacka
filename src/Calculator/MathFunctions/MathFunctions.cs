using System;

namespace MathFunctions
{
    public class MathFunction
    {
        // Singleton class
        private static MathFunction instance = null;

        public static MathFunction GetInstance()
        {
            if (instance == null)
            {
                instance = new MathFunction();
            }
            return instance;
        }

        // Here comes all math functions
        public float Sum(float a, float b)
        {
            return a + b;
        }

        public float Substract(float a, float b)
        {
            return a - b;
        }

        public float Multiply(float a, float b)
        {
            return a * b;
        }

        public float Divide(float a, float b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            return a / b;
        }

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

        public float Power(float a, int b)
        {
            float result = 1;
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

        public float Root(float a, int b)
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
                return (float)Math.Round(result, round_coeficient);
            }
            else
            {
                // if "b" is odd and "a" is negative, function Math.Pow() returns NaN instead of negative result
                // we use "-a" -> (negative "a") and calculate nth root of it, then return "-result" -> negative result

                // Rounding number to X digits to eliminate inaccuracy
                double result = -Math.Pow(-a, 1F / b);
                return (float)Math.Round(result, round_coeficient);
            }
        }

        public float Fibbonacci(int a)
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
