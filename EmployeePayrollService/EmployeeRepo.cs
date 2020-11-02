using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        public static string connectionString = @" Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=PayRollAssignment;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                EmployeePayroll employeePayroll = new EmployeePayroll();
                using (this.connection)
                {
                    string query = @"select * from Employee_payroll";
                    SqlCommand cnd = new SqlCommand(query, this.connection);
                    this.connection.Open();

                    SqlDataReader dr = cnd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeePayroll.EmployeeID = dr.GetInt32(0);
                            employeePayroll.EmployeeName = dr.GetString(1);
                            employeePayroll.StartDate = dr.GetDateTime(3);
                            employeePayroll.Gender = dr.GetString(4);
                            employeePayroll.Address = dr.GetString(6);
                            employeePayroll.PhoneNumber = dr.GetString(5);

                            Console.WriteLine(employeePayroll.EmployeeID + "  " + employeePayroll.EmployeeName + "  " + employeePayroll.StartDate + "  " + employeePayroll.Gender + "  " + employeePayroll.Address + "  " + employeePayroll.PhoneNumber);
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No DAta found");
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
        
