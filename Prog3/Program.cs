using System;

namespace Prog3
{
    // Question 3: Explain the difference between unicast and multicast delegates.
    // Write a program demonstrating both.

    public delegate void DisplayDelegate(string message);

    class Program
    {
        public static void MethodA(string msg)
        {
            Console.WriteLine($"  [MethodA] Executed with message: '{msg}'");
        }

        public static void MethodB(string msg)
        {
            Console.WriteLine($"  [MethodB] Executed with message: '{msg}'");
        }

        public static void MethodC(string msg)
        {
            Console.WriteLine($"  [MethodC] Executed with message: '{msg}'");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("  QUESTION 3: Unicast vs Multicast Delegates");
            Console.WriteLine("==========================================================================");
            Console.WriteLine();
            Console.WriteLine("--- EXPLANATION ---");
            Console.WriteLine("1. Unicast Delegate:");
            Console.WriteLine("   - Points to a SINGLE target method.");
            Console.WriteLine("   - When invoked, only that one method is executed.");
            Console.WriteLine();
            Console.WriteLine("2. Multicast Delegate:");
            Console.WriteLine("   - Points to MULTIPLE target methods simultaneously in an invocation list.");
            Console.WriteLine("   - Created using the '+' or '+=' operator.");
            Console.WriteLine("   - Methods can be removed from the invocation list using the '-' or '-=' operator.");
            Console.WriteLine("   - When invoked, methods are executed sequentially in the order added.");
            Console.WriteLine();

            Console.WriteLine("--- DEMONSTRATION ---");
            Console.WriteLine("[1] Unicast Delegate Demonstration:");
            DisplayDelegate unicastDel = MethodA; // Points only to MethodA
            unicastDel("Unicast test payload");

            Console.WriteLine();
            Console.WriteLine("[2] Multicast Delegate Demonstration (Adding MethodA, MethodB, MethodC):");
            DisplayDelegate? multicastDel = MethodA;
            multicastDel += MethodB; // Combining MethodB
            multicastDel += MethodC; // Combining MethodC

            Console.WriteLine("Invoking multicast delegate:");
            multicastDel("Multicast test payload");

            Console.WriteLine();
            Console.WriteLine("[3] Multicast Delegate Demonstration (Removing MethodB):");
            multicastDel -= MethodB; // Removing MethodB from invocation list

            Console.WriteLine("Invoking multicast delegate after removing MethodB:");
            multicastDel?.Invoke("Post-removal payload");

            Console.WriteLine();
            Console.WriteLine("==========================================================================");
        }
    }
}