using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to employee payroll");
            EmployeeRepo repo = new EmployeeRepo();

            //UC2 get all the employee Details

            string query = @"select * from Employee_payroll";
            repo.GetAllEmployee(query);

            //Insert some record into employee table

            EmployeePayroll employee = new EmployeePayroll();
            employee.name = "Rahul";
            employee.startDate = Convert.ToDateTime("2020-10-01");
            employee.gender = 'M';
            employee.Address = "Karnataka";
            employee.phoneNumber = "+91 9866528888";


            repo.UpdateEmployeeSalaryUsingStoredProcedure("Karan", 43540);





        }
    }
}