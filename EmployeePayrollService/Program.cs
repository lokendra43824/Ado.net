using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to employee payroll");
            EmployeeRepo repo = new EmployeeRepo();

            

            repo.UpdateEmployeeAddressUsingStoredProcedure("lokendra", "43540");


        }
    }
}