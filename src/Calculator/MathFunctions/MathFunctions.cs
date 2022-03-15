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
    }
}
