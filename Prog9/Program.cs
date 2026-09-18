using System;

namespace Prog9
{
    // Question 9: What is the built-in Func delegate? Write a program using Func with methods
    // that accept input values and return a result. Also demonstrate a multicast Func delegate
    // and use GetInvocationList() to invoke each method separately and display all returned values.

    class Program
    {
        // Target methods accepting double and returning double
        public static double CalculateSquare(double number)
        {
            return number * number;
        }

        public static double CalculateCube(double number)
        {
            return number * number * number;
        }

        public static double CalculateSquareRoot(double number)
        {
            return Math.Sqrt(number);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("  QUESTION 9: Built-in Func Delegate & Multicast Invocation");
            Console.WriteLine("==========================================================================");
            Console.WriteLine();
            Console.WriteLine("--- EXPLANATION ---");
            Console.WriteLine("What is Func?");
            Console.WriteLine("  - 'Func' is a built-in generic delegate defined in the System namespace.");
            Console.WriteLine("  - It encapsulates a method that takes 0 to 16 input parameters and ALWAYS returns a value.");
            Console.WriteLine("  - The LAST generic parameter specifies the return type.");
            Console.WriteLine("  - Example: Func<double, double> takes a double input and returns a double result.");
            Console.WriteLine();

            Console.WriteLine("--- DEMONSTRATION ---");
            double inputValue = 16.0;

            // 1. Unicast Func Delegate
            Console.WriteLine($"[1] Unicast Func<double, double>:");
            Func<double, double> unicastFunc = CalculateSquare;
            double squareResult = unicastFunc(inputValue);
            Console.WriteLine($"  Square of {inputValue} = {squareResult}");

            Console.WriteLine();

            // 2. Multicast Func Delegate & Why GetInvocationList() is needed
            Console.WriteLine("[2] Multicast Func<double, double>:");
            Func<double, double> multicastFunc = CalculateSquare;
            multicastFunc += CalculateCube;
            multicastFunc += CalculateSquareRoot;

            Console.WriteLine($"  Direct Multicast Call result: {multicastFunc(inputValue)}");
            Console.WriteLine("  (Note: Direct invocation of a multicast Func returns ONLY the result of the LAST method in the invocation list!)");
            Console.WriteLine();

            // 3. Using GetInvocationList() to capture ALL returned values
            Console.WriteLine("[3] Invoking Each Method in Multicast Func via GetInvocationList():");
            Delegate[] targets = multicastFunc.GetInvocationList();

            foreach (Delegate del in targets)
            {
                Func<double, double> singleFunc = (Func<double, double>)del;
                double result = singleFunc(inputValue);
                Console.WriteLine($"  Method: {del.Method.Name,-20} | Input: {inputValue,4} | Returned Result: {result}");
            }

            Console.WriteLine();
            Console.WriteLine("==========================================================================");
        }
    }
}
