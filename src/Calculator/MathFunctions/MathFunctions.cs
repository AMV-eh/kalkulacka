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
            throw new NotImplementedException();
        }

        public float Multiply(float a, float b)
        {
            throw new NotImplementedException();
        }

        public float Divide(float a, float b)
        {
            throw new NotImplementedException();
        }

        public int Factorial(int a)
        {
            throw new NotImplementedException();
        }

        public float Power(float a, uint b)
        {
            throw new NotImplementedException();
        }

        public float Root(float a, uint b)
        {
            throw new NotImplementedException();
        }
    }
}
