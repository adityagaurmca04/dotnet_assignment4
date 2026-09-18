using System;

namespace Prog2
{
    public delegate int AdditionDelegate(int num1, int num2);

    class Program
    {
        public static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("  QUESTION 2: Delegate Returning Sum of Two Integers");
            Console.WriteLine("==========================================================================");
            Console.WriteLine();

            int val1 = 45;
            int val2 = 35;

            AdditionDelegate sumDelegate = new AdditionDelegate(AddNumbers);

            int result1 = sumDelegate(val1, val2);
            Console.WriteLine($"Input Values : {val1} and {val2}");
            Console.WriteLine($"Direct Call  : {val1} + {val2} = {result1}");

            int result2 = sumDelegate.Invoke(100, 250);
            Console.WriteLine($"Invoke Call  : 100 + 250 = {result2}");

            Console.WriteLine();
            Console.WriteLine("==========================================================================");
        }
    }
}
