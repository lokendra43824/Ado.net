using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;

namespace UnitTestProject2
{
    [TestClass]
    namespace UnitTestProject1
    {
        [TestClass]
        public class UnitTest1
        {

            //UC3 Update salary based on name
            //  [TestMethod]
            public void UpdateSalaryForAGivenEmployee()
            {
                EmployeeRepo repo = new EmployeeRepo();

                Transaction payments = repo.UpdateEmployeeSalary();
                decimal expected = 43500;
                decimal actual = Transaction.net_pay;
                Assert.AreEqual(expected, actual);

            }

            //UC4 Update Adress using stored procedure
            //  [TestMethod]
            public void UpdateSalaryUsingStoredProcedure()
            {

                EmployeeRepo repo = new EmployeeRepo();
                Transaction payments = repo.UpdateEmployeeAddressUsingStoredProcedure("lokendra", "CHENNAI");
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
                string actual1 = list[0].name;
                string expected = "lokendra";
                Assert.AreEqual(expected, actual1);
                
               

            }
            //UC6 Operation on Salaries

            [TestMethod]

            public void GetTheGenderWiseSumOfSalaries()
            {
                EmployeeRepo repo = new EmployeeRepo();
                string query = @"select a.gender,sum(b.net_pay)SumOfSalaries from Employee_payroll a inner join payments b on a.id = b.id group by a.gender";
                Dictionary<string, decimal> dictionary = repo.OperationOnSalaries(query);

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
                Dictionary<string, decimal> dictionary = repo.OperationOnSalaries(query);

                decimal actualAvgFemale = dictionary["F"];
                decimal expectedAvgFemale = 32500;


                decimal actualAvgMale = dictionary["M"];
                decimal expectedAvgMale = 38372.5M;

                Assert.AreEqual(expectedAvgFemale, actualAvgFemale);
                Assert.AreEqual(expectedAvgMale, actualAvgMale);
            }



            //UC7
            //     [TestMethod]

            public void UpdatePayRollTableWhenAddedDataToEmployeePayRoll()
            {
                EmployeeRepo repo = new EmployeeRepo();
                EmployeePayroll employee = new EmployeePayroll();
                employee.name = "sharuk";
                employee.startDate = Convert.ToDateTime("2018-10-01");
                employee.gender = 'M';
                employee.Address = "HYDERABAD";
                employee.phoneNumber = "+91 9492227638";
                Transaction actual = repo.addEmployee(employee);



                decimal expectedBasicPay = 34500;
                decimal actualBasicSalary = actual.basicPay;

                Assert.AreEqual(expectedBasicPay, actualBasicSalary);

                decimal expectedNetSalary = 31450;
                decimal actualNetSalary = actual.net_pay;

                Assert.AreEqual(expectedNetSalary, actualNetSalary);


            }



        }

    }
