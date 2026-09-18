using System;

namespace Prog2
{
    // Question 2: Create a delegate that accepts two integer values and returns their sum.
    // Create an appropriate method and invoke it using the delegate.

    // 1. Declare delegate taking two integers and returning an integer
    public delegate int AdditionDelegate(int num1, int num2);

    class Program
    {
        // 2. Target method that accepts two integers and returns their sum
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

            // 3. Instantiate delegate pointing to AddNumbers method
            AdditionDelegate sumDelegate = new AdditionDelegate(AddNumbers);

            // 4. Invoke delegate using direct function call syntax
            int result1 = sumDelegate(val1, val2);
            Console.WriteLine($"Input Values : {val1} and {val2}");
            Console.WriteLine($"Direct Call  : {val1} + {val2} = {result1}");

            // 5. Invoke delegate using explicit .Invoke() method
            int result2 = sumDelegate.Invoke(100, 250);
            Console.WriteLine($"Invoke Call  : 100 + 250 = {result2}");

            Console.WriteLine();
            Console.WriteLine("==========================================================================");
        }
    }
}
