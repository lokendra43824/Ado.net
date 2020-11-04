using EmployeePayrollService;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
   
        [TestClass]
        public class UnitTest1
        {
            //  [TestMethod]
            public void UpdateSalaryForAGivenEmployee()
            {
                EmployeeRepo repo = new EmployeeRepo();

                Transactions payments = repo.UpdateEmployeeSalary();
                decimal expected = 43500;
                Assert.AreEqual(expected, payments.net_pay);

            }


            // [TestMethod]
            public void UpdateAddressUsingStoredProcedure()
            {

                EmployeeRepo repo = new EmployeeRepo();
                bool actual = repo.UpdateEmployeeAddressUsingStoredProcedure("lokendra", "CHENNAI");
                string expected = "CHENNAI";

                Assert.AreEqual(expected, actual);
            }


        }
    }
