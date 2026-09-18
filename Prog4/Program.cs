using System;

namespace Prog4
{
    // Question 4: Create a delegate for a calculator application.
    // Use the same delegate to invoke methods for addition, subtraction, multiplication, and division.

    // Define delegate for calculator operations accepting two doubles and returning double
    public delegate double CalculatorDelegate(double x, double y);

    class Program
    {
        // Calculator operation methods
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

        // Helper method to execute calculation using the delegate instance
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

            // Single delegate variable reused for all 4 operations
            CalculatorDelegate calcDelegate;

            // 1. Addition
            calcDelegate = Add;
            PerformCalculation("Addition", calcDelegate, num1, num2);

            // 2. Subtraction
            calcDelegate = Subtract;
            PerformCalculation("Subtraction", calcDelegate, num1, num2);

            // 3. Multiplication
            calcDelegate = Multiply;
            PerformCalculation("Multiplication", calcDelegate, num1, num2);

            // 4. Division
            calcDelegate = Divide;
            PerformCalculation("Division", calcDelegate, num1, num2);

            Console.WriteLine();
            Console.WriteLine("==========================================================================");
        }
    }
}
