using System;

namespace Prog6
{
    // Question 6: Employee Salary Calculation using separate methods and GetInvocationList() on a multicast delegate.

    // Multicast delegate accepting basic salary and returning salary component amount
    public delegate double SalaryComponentDelegate(double basicSalary);

    class Program
    {
        // 1. Basic Salary component
        public static double GetBasicSalary(double basicSalary)
        {
            return basicSalary;
        }

        // 2. HRA (20% of Basic Salary)
        public static double CalculateHRA(double basicSalary)
        {
            return basicSalary * 0.20;
        }

        // 3. DA (10% of Basic Salary)
        public static double CalculateDA(double basicSalary)
        {
            return basicSalary * 0.10;
        }

        // 4. Bonus (15% of Basic Salary)
        public static double CalculateBonus(double basicSalary)
        {
            return basicSalary * 0.15;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("  QUESTION 6: Multicast Delegate for Employee Salary Breakdown");
            Console.WriteLine("==========================================================================");
            Console.WriteLine();

            double employeeBasicSalary = 50000.00;

            // Combine methods into multicast delegate
            SalaryComponentDelegate salaryCalculator = GetBasicSalary;
            salaryCalculator += CalculateHRA;
            salaryCalculator += CalculateDA;
            salaryCalculator += CalculateBonus;

            Console.WriteLine($"Employee Basic Salary Input: ₹{employeeBasicSalary:N2}");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine($"  {"Salary Component",-25} | {"Method Name",-20} | {"Amount (₹)",12}");
            Console.WriteLine("--------------------------------------------------------------------------");

            double totalSalary = 0.0;

            // Get invocation list to execute each method separately and retrieve every return value
            Delegate[] invocationList = salaryCalculator.GetInvocationList();

            foreach (Delegate singleDelegate in invocationList)
            {
                // Cast to target delegate type and invoke
                SalaryComponentDelegate componentMethod = (SalaryComponentDelegate)singleDelegate;
                double componentAmount = componentMethod(employeeBasicSalary);

                string methodName = singleDelegate.Method.Name;
                string labelName = methodName switch
                {
                    nameof(GetBasicSalary) => "Basic Salary",
                    nameof(CalculateHRA) => "HRA (20%)",
                    nameof(CalculateDA) => "DA (10%)",
                    nameof(CalculateBonus) => "Bonus (15%)",
                    _ => methodName
                };

                Console.WriteLine($"  {labelName,-25} | {methodName,-20} | ₹{componentAmount,10:N2}");
                totalSalary += componentAmount;
            }

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine($"  {"Total Gross Salary",-25} | {"",-20} | ₹{totalSalary,10:N2}");
            Console.WriteLine("==========================================================================");
        }
    }
}
