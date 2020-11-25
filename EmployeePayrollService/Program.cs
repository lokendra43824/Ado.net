using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to employee payroll");
            EmployeeRepo repo = new EmployeeRepo();

            //UC1 connect with database

            string query = @"select * from Employee_payroll";
            repo.GetAllEmployee(query);



        }
    }
}
