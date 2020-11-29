using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to employee payroll");
            EmployeeRepo repo = new EmployeeRepo();           

            // repo.UpdateEmployeeSalaryUsingStoredProcedure("Karan", 43540);

            //Get the employees who joined after certain date range
            string query = @"select* from Employee_payroll where start_Date between CAST('2020-01-01' as date) and GETDATE()";
            repo.GetAllEmployee(query);





        }
    }
}