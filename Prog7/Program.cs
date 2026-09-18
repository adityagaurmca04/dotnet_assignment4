using System;

namespace Prog7
{
    // Question 7: Create a multicast delegate containing at least three methods.
    // Use GetInvocationList() to display the names of all methods stored in the delegate and invoke them individually.

    public delegate void WorkflowDelegate(string taskName);

    class Program
    {
        // 3 target methods
        public static void ValidateTask(string taskName)
        {
            Console.WriteLine($"  -> Executed [ValidateTask] for: '{taskName}'");
        }

        public static void ProcessTask(string taskName)
        {
            Console.WriteLine($"  -> Executed [ProcessTask]  for: '{taskName}'");
        }

        public static void AuditLogTask(string taskName)
        {
            Console.WriteLine($"  -> Executed [AuditLogTask] for: '{taskName}'");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("  QUESTION 7: Inspecting & Invoking Methods via GetInvocationList()");
            Console.WriteLine("==========================================================================");
            Console.WriteLine();

            // Create multicast delegate with 3 methods
            WorkflowDelegate workflow = ValidateTask;
            workflow += ProcessTask;
            workflow += AuditLogTask;

            // Retrieve all methods stored in the delegate
            Delegate[] delegateList = workflow.GetInvocationList();

            Console.WriteLine($"Total Methods attached to Multicast Delegate: {delegateList.Length}");
            Console.WriteLine("--------------------------------------------------");

            // Display names of all methods stored in delegate
            Console.WriteLine("\n[1] Displaying Target Method Names in Invocation List:");
            for (int i = 0; i < delegateList.Length; i++)
            {
                Console.WriteLine($"  Method #{i + 1}: {delegateList[i].Method.Name} (Declaring Type: {delegateList[i].Method.DeclaringType?.Name})");
            }

            // Invoke each method individually using GetInvocationList()
            Console.WriteLine("\n[2] Invoking Each Method Individually:");
            for (int i = 0; i < delegateList.Length; i++)
            {
                Console.WriteLine($"\n--- Invoking Method #{i + 1}: {delegateList[i].Method.Name} ---");
                // Option A: DynamicInvoke
                delegateList[i].DynamicInvoke($"Data Processing Step {i + 1}");

                // Option B: Direct type cast invocation
                // ((WorkflowDelegate)delegateList[i])($"Data Processing Step {i + 1}");
            }

            Console.WriteLine();
            Console.WriteLine("==========================================================================");
        }
    }
}
