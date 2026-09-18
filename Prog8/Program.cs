using System;

namespace Prog8
{
    // Question 8: What is the built-in Action delegate? Create a program demonstrating
    // both unicast and multicast Action delegates without using lambda expressions.

    class Program
    {
        // Named methods matching Action<string> signature (accepts string, returns void)
        public static void PrintMessage(string message)
        {
            Console.WriteLine($"  [PrintMessage] Standard Output: {message}");
        }

        public static void PrintUppercase(string message)
        {
            Console.WriteLine($"  [PrintUppercase] UPPERCASE Output: {message.ToUpper()}");
        }

        public static void PrintDecorated(string message)
        {
            Console.WriteLine($"  [PrintDecorated] *** {message} ***");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("  QUESTION 8: Built-in Action Delegate (Unicast & Multicast)");
            Console.WriteLine("==========================================================================");
            Console.WriteLine();
            Console.WriteLine("--- EXPLANATION ---");
            Console.WriteLine("What is Action?");
            Console.WriteLine("  - 'Action' is a built-in generic delegate defined in the System namespace.");
            Console.WriteLine("  - It encapsulates a method that takes 0 to 16 parameters and DOES NOT return a value (void).");
            Console.WriteLine("  - Signatures: Action, Action<T>, Action<T1, T2>, ..., Action<T1, ..., T16>");
            Console.WriteLine("  - Advantage: Eliminates the need to declare custom delegate types for void methods.");
            Console.WriteLine();

            Console.WriteLine("--- DEMONSTRATION (Without Lambda Expressions) ---");
            
            // 1. Unicast Action Delegate
            Console.WriteLine("[1] Unicast Action<string> Delegate:");
            Action<string> unicastAction = PrintMessage;
            unicastAction("Hello from Unicast Action!");

            Console.WriteLine();

            // 2. Multicast Action Delegate
            Console.WriteLine("[2] Multicast Action<string> Delegate (Combining 3 Named Methods):");
            Action<string> multicastAction = PrintMessage;
            multicastAction += PrintUppercase;
            multicastAction += PrintDecorated;

            Console.WriteLine("Invoking multicast Action<string>:");
            multicastAction("Built-in Action delegates are convenient!");

            Console.WriteLine();
            Console.WriteLine("==========================================================================");
        }
    }
}
