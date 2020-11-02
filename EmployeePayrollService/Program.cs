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
            employee.EmployeeName = "lokendra";
            employee.PhoneNumber = "8919445458";
            employee.Address = "1-30,CTR,AP";
            employee.Department = "BUSINESS";
            employee.Gender = "M";
            employee.BasicPay = "30000";
            employee.Deductions = "500";
            employee.TaxablePay = "1500";
            employee.Tax = "2000";
            employee.NetPay = "50000";
            employee.City = "TPT";
            employee.Country = "India";

            repo.GetAllEmployee();
        }
    }
}
