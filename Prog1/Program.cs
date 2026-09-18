using System;

namespace Prog1
{
    public delegate void GreetDelegate(string name);

    class Program
    {
        public static void SayHello(string name)
        {
            Console.WriteLine($"  [SayHello] Hello, {name}! Welcome to C# Delegates.");
        }

        public static void SayGoodbye(string name)
        {
            Console.WriteLine($"  [SayGoodbye] Goodbye, {name}! Have a great day.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("  QUESTION 1: C# Delegates - Definition, Purpose, and Syntax");
            Console.WriteLine("==========================================================================");
            Console.WriteLine();
            Console.WriteLine("--- EXPLANATION ---");
            Console.WriteLine("1. What is a Delegate?");
            Console.WriteLine("   A delegate in C# is a type-safe function pointer. It encapsulates a method");
            Console.WriteLine("   reference with a specific signature and return type.");
            Console.WriteLine();
            Console.WriteLine("2. Purpose of Delegates:");
            Console.WriteLine("   - To pass methods as arguments to other methods (callbacks).");
            Console.WriteLine("   - To implement event-driven programming.");
            Console.WriteLine("   - To decouple caller logic from target method implementations.");
            Console.WriteLine();
            Console.WriteLine("3. Syntax:");
            Console.WriteLine("   - Declaration:  delegate <return_type> <DelegateName>(<parameters>);");
            Console.WriteLine("   - Instantiation: <DelegateName> del = new <DelegateName>(MethodName);");
            Console.WriteLine("                     OR method group conversion: <DelegateName> del = MethodName;");
            Console.WriteLine("   - Invocation:    del(args); OR del.Invoke(args);");
            Console.WriteLine();
            Console.WriteLine("--- PROGRAM DEMONSTRATION ---");

            Console.WriteLine("1. Explicit Instantiation & Direct Call:");
            GreetDelegate greet1 = new GreetDelegate(SayHello);
            greet1("Aditya");

            Console.WriteLine();
            Console.WriteLine("2. Method Group Conversion & Explicit .Invoke():");
            GreetDelegate greet2 = SayGoodbye;
            greet2.Invoke("Aditya");

            Console.WriteLine();
            Console.WriteLine("==========================================================================");
        }
    }
}
