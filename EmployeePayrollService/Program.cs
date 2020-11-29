using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to employee payroll");
            EmployeeRepo repo = new EmployeeRepo();
            

            string query = @"select a.gender,sum(b.net_pay)SumOfSalaries from Employee_payroll a inner join payments b on a.id = b.id group by a.gender";
            //string query = @"select a.gender,avg(b.net_pay)AvgOfSalaries from Employee_payroll a inner join payments b on a.id=b.id group by a.gender";
            // string query = @"select a.gender,max(b.net_pay)AvgOfSalaries from Employee_payroll a inner join payments b on a.id = b.id group by a.gender";
            // String query = @"select a.gender,min(b.net_pay)AvgOfSalaries from Employee_payroll a inner join payments b on a.id = b.id group by a.gender";
            repo.OperationOnSalaries(query);



        }
    }
}