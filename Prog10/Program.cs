using System;

namespace Prog10
{
    class Program
    {
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public static bool IsPositive(int number)
        {
            return number > 0;
        }

        public static bool IsGreaterThan100(int number)
        {
            return number > 100;
        }

        public static void EvaluateNumber(int testValue, Predicate<int> predicateChain)
        {
            Console.WriteLine($"\n--- Evaluating Number: {testValue} ---");
            Console.WriteLine($"{"Check Method",-25} | {"Condition Test",-20} | {"Result",-10}");
            Console.WriteLine("------------------------------------------------------------------");

            Delegate[] invocationList = predicateChain.GetInvocationList();

            foreach (Delegate item in invocationList)
            {
                Predicate<int> singlePredicate = (Predicate<int>)item;
                bool isSatisfied = singlePredicate(testValue);

                string methodName = item.Method.Name;
                string description = methodName switch
                {
                    nameof(IsEven) => "Is Even Number?",
                    nameof(IsPositive) => "Is Positive Number?",
                    nameof(IsGreaterThan100) => "Is Greater Than 100?",
                    _ => methodName
                };

                Console.WriteLine($"  {methodName,-23} | {description,-20} | {isSatisfied,-10}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("  QUESTION 10: Built-in Predicate<T> Delegate & Multicast Invocation");
            Console.WriteLine("==========================================================================");
            Console.WriteLine();
            Console.WriteLine("--- EXPLANATION ---");
            Console.WriteLine("What is Predicate<T>?");
            Console.WriteLine("  - 'Predicate<T>' is a built-in generic delegate in System namespace.");
            Console.WriteLine("  - Signature: delegate bool Predicate<in T>(T obj)");
            Console.WriteLine("  - It encapsulates a method that accepts a single argument of type T and ALWAYS returns a bool.");
            Console.WriteLine("  - It is equivalent to Func<T, bool> and is commonly used for filtering or criteria verification.");
            Console.WriteLine();

            Predicate<int> numberChecks = IsEven;
            numberChecks += IsPositive;
            numberChecks += IsGreaterThan100;

            EvaluateNumber(150, numberChecks);
            EvaluateNumber(-42, numberChecks);
            EvaluateNumber(77, numberChecks);

            Console.WriteLine();
            Console.WriteLine("==========================================================================");
        }
    }
}
