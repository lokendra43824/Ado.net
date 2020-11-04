using System;

namespace EmployeePayrollService
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to employee payroll");
            EmployeeRepo repo = new EmployeeRepo();
            EmployeePayroll employee = new EmployeePayroll();
           

            employee.EmployeeName = "harish";
            employee.StartDate = Convert.ToDateTime("2020-10-01");
            employee.Gender = 'M';
            employee.Address = "mumbai";
            employee.PhoneNumber = "+91 9866528888";
            

            string query = @"select * from Employee_payroll";
            repo.GetAllEmployee(query);
            // repo.UpdateEmployeeAddressUsingStoredProcedure("lokendra","HYD");
            //repo.AddEmployeeDetailsUsingStoredProcedure(employee);
            //repo.GetAllSalaries();
        }
    }
}