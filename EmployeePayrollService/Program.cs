using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to employee payroll");
            EmployeeRepo repo = new EmployeeRepo();

            EmployeePayroll employee = new EmployeePayroll();
            employee.name = "Rahul";
            employee.startDate = Convert.ToDateTime("2020-10-01");
            employee.gender = 'M';
            employee.Address = "Karnataka";
            employee.phoneNumber = "+91 9866528888";
            repo.addEmployee(employee);
        }
    }
}