using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeeRepo
    {
        public static string connectionString = @" Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=PayRollAssignment;Integrated Security=True";
        static SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEmployee(string query)
        {
            try
            {
                EmployeePayroll employeePayroll = new EmployeePayroll();
                using (connection)
                {

                    SqlCommand cnd = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader dr = cnd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeePayroll.id = dr.GetInt32(0);
                            employeePayroll.name = dr.GetString(1);
                            employeePayroll.startDate = dr.GetDateTime(2);
                            employeePayroll.gender = Convert.ToChar(dr.GetString(3));
                            employeePayroll.Address = dr.GetString(4);
                            employeePayroll.phoneNumber = dr.GetString(5);

                            Console.WriteLine(employeePayroll.id + "  " + employeePayroll.name + "  " + employeePayroll.startDate + "  " + employeePayroll.gender + "  " + employeePayroll.Address + "  " + employeePayroll.phoneNumber);
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No DAta found");
                    }
                    dr.Close();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }


    }
}
        
