using EmployeePayrollService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace UnitTestProject2
{
    
    namespace UnitTestProject1
    {
        [TestClass]
        public class Test
        {
             public void GetTimeOfJoining()
            {
                List<EmployeePayroll> employees = new List<EmployeePayroll>();
                DateTime time = new DateTime(2020, 10, 1);
                employees.Add(new Employeepayroll("rohith", time, 'M', "DELHI", "+91 9876543210"));
                employees.Add(new EmployeePayroll("kishan", time, 'M', "DELHI", "+91 9876543210"));
                employees.Add(new EmployeePayroll("surya", time, 'M', "DELHI", "+91 9876543210"));
                employees.Add(new EmployeePayroll("hardik", time, 'M', "DELHI", "+91 9876543210"));
                employees.Add(new EmployeePayroll("pollard", time, 'M', "DELHI", "+91 9876543210"));
                employees.Add(new EmployeePayroll("krunal", time, 'M', "DELHI", "+91 9876543210"));

                DateTime startTime = DateTime.Now;

                EmployeeRepo repo = new EmployeeRepo();
                repo.addMultipleEmpoyees(employees);
                DateTime endTime = DateTime.Now;

                TimeSpan timeTook = endTime - startTime;


            }



            /* //UC4 Update Adress using stored procedure
             //  [TestMethod]
             public void UpdateAddressUsingStoredProcedure()
             {

                 EmployeeRepo repo = new EmployeeRepo();
                 Transactions payments = repo.UpdateEmployeeAddressUsingStoredProcedure("lokendra", "CHENNAI");
                 string expected = "CHENNAI";
                 decimal actual = payments.Address;
                 Assert.AreEqual(expected, actual);
             }


             //UC5 Employees joined after certain date
             //   [TestMethod]
             public void EmployeesJoinedAfterCertainDate()
             {
                 EmployeeRepo repo = new EmployeeRepo();
                 string query = @"select* from Employee_payroll where start_Date between CAST('2020-01-01' as date) and GETDATE()";
                 List<EmployeePayroll> list = repo.GetAllEmployee(query);
                 string actual1 = list[0].EmployeeName;
                 string expected = "lokendra";
                 Assert.AreEqual(expected, actual1);



             }
             //UC6 Operation on Salaries

             [TestMethod]

             public void GetTheGenderWiseSumOfSalaries()
             {
                 EmployeeRepo repo = new EmployeeRepo();
                 string query = @"select a.gender,sum(b.net_pay)SumOfSalaries from Employee_payroll a inner join payments b on a.id = b.id group by a.gender";
                 Dictionary<string, decimal> dictionary = repo.RetrieveAllSalaries(query);

                 decimal actualSumFemale = dictionary["F"];
                 decimal expectedSumFemale = 65000;


                 decimal actualSumMale = dictionary["M"];
                 decimal expectedSumMale = 153490;

                 Assert.AreEqual(expectedSumFemale, actualSumFemale);
                 Assert.AreEqual(expectedSumMale, actualSumMale);
             }

             //   [TestMethod]
             public void GetTheGenderWiseAvgOfSalaries()
             {
                 EmployeeRepo repo = new EmployeeRepo();
                 string query = @"select a.gender,avg(b.net_pay)SumOfSalaries from Employee_payroll a inner join payments b on a.id = b.id group by a.gender";
                 Dictionary<string, decimal> dictionary = repo.RetrieveAllSalaries(query);

                 decimal actualAvgFemale = dictionary["F"];
                 decimal expectedAvgFemale = 32500;


                 decimal actualAvgMale = dictionary["M"];
                 decimal expectedAvgMale = 38372.5M;

                 Assert.AreEqual(expectedAvgFemale, actualAvgFemale);
                 Assert.AreEqual(expectedAvgMale, actualAvgMale);
             }*/





        }

    }
}