using System;

namespace Prog9
{
    class Program
    {
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

            Console.WriteLine($"[1] Unicast Func<double, double>:");
            Func<double, double> unicastFunc = CalculateSquare;
            double squareResult = unicastFunc(inputValue);
            Console.WriteLine($"  Square of {inputValue} = {squareResult}");

            Console.WriteLine();

            Console.WriteLine("[2] Multicast Func<double, double>:");
            Func<double, double> multicastFunc = CalculateSquare;
            multicastFunc += CalculateCube;
            multicastFunc += CalculateSquareRoot;

            Console.WriteLine($"  Direct Multicast Call result: {multicastFunc(inputValue)}");
            Console.WriteLine("  (Note: Direct invocation of a multicast Func returns ONLY the result of the LAST method in the invocation list!)");
            Console.WriteLine();

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
