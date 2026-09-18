using System;

namespace Prog7
{
    public delegate void WorkflowDelegate(string taskName);

    class Program
    {
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

            WorkflowDelegate workflow = ValidateTask;
            workflow += ProcessTask;
            workflow += AuditLogTask;

            Delegate[] delegateList = workflow.GetInvocationList();

            Console.WriteLine($"Total Methods attached to Multicast Delegate: {delegateList.Length}");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("\n[1] Displaying Target Method Names in Invocation List:");
            for (int i = 0; i < delegateList.Length; i++)
            {
                Console.WriteLine($"  Method #{i + 1}: {delegateList[i].Method.Name} (Declaring Type: {delegateList[i].Method.DeclaringType?.Name})");
            }

            Console.WriteLine("\n[2] Invoking Each Method Individually:");
            for (int i = 0; i < delegateList.Length; i++)
            {
                Console.WriteLine($"\n--- Invoking Method #{i + 1}: {delegateList[i].Method.Name} ---");
                delegateList[i].DynamicInvoke($"Data Processing Step {i + 1}");
            }

            Console.WriteLine();
            Console.WriteLine("==========================================================================");
        }
    }
}
