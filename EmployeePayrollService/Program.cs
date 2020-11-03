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
           
            employee.EmployeeName = "Dhoni";
            employee.StartDate = Convert.ToDateTime("2020-10-01");
            employee.Gender = 'M';
            employee.Address = "DELHI";
            employee.PhoneNumber = "+91 9866528888";
            
            string query = @"select * from Employee_payroll";
            repo.GetAllEmployee(query);
            // repo.UpdateEmployeeSalaryUsingStoredProcedure("lokendra","HYD");
           // repo.addEmpoyee(employee);
        }
    }
}
