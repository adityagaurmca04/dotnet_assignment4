using System;

namespace Prog6
{
    public delegate double SalaryComponentDelegate(double basicSalary);

    class Program
    {
        public static double GetBasicSalary(double basicSalary)
        {
            return basicSalary;
        }

        public static double CalculateHRA(double basicSalary)
        {
            return basicSalary * 0.20;
        }

        public static double CalculateDA(double basicSalary)
        {
            return basicSalary * 0.10;
        }

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

            SalaryComponentDelegate salaryCalculator = GetBasicSalary;
            salaryCalculator += CalculateHRA;
            salaryCalculator += CalculateDA;
            salaryCalculator += CalculateBonus;

            Console.WriteLine($"Employee Basic Salary Input: ₹{employeeBasicSalary:N2}");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine($"  {"Salary Component",-25} | {"Method Name",-20} | {"Amount (₹)",12}");
            Console.WriteLine("--------------------------------------------------------------------------");

            double totalSalary = 0.0;

            Delegate[] invocationList = salaryCalculator.GetInvocationList();

            foreach (Delegate singleDelegate in invocationList)
            {
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
