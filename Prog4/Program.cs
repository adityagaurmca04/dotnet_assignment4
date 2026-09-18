using System;

namespace Prog4
{
    public delegate double CalculatorDelegate(double x, double y);

    class Program
    {
        public static double Add(double x, double y) => x + y;
        public static double Subtract(double x, double y) => x - y;
        public static double Multiply(double x, double y) => x * y;
        public static double Divide(double x, double y)
        {
            if (y == 0)
            {
                Console.WriteLine("  [Error] Division by zero is undefined.");
                return double.NaN;
            }
            return x / y;
        }

        public static void PerformCalculation(string operationName, CalculatorDelegate calcDel, double a, double b)
        {
            double result = calcDel(a, b);
            Console.WriteLine($"  {operationName,-15}: {a} and {b} => Result = {result}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("  QUESTION 4: Calculator Application Using Single Delegate");
            Console.WriteLine("==========================================================================");
            Console.WriteLine();

            double num1 = 20.0;
            double num2 = 5.0;

            Console.WriteLine($"Operating on numbers: {num1} and {num2}");
            Console.WriteLine("--------------------------------------------------");

            CalculatorDelegate calcDelegate;

            calcDelegate = Add;
            PerformCalculation("Addition", calcDelegate, num1, num2);

            calcDelegate = Subtract;
            PerformCalculation("Subtraction", calcDelegate, num1, num2);

            calcDelegate = Multiply;
            PerformCalculation("Multiplication", calcDelegate, num1, num2);

            calcDelegate = Divide;
            PerformCalculation("Division", calcDelegate, num1, num2);

            Console.WriteLine();
            Console.WriteLine("==========================================================================");
        }
    }
}
