﻿using System;
using System.Collections.Generic;
using System.Data;
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

      
        public Payments UpdateEmployeeSalary()
        {
            try
            {

                using (connection)
                {
                    Payments payments = new Payments();
                    string query = @"update payments set payments.net_pay=43500 from payments p inner join Employee_payroll e on p.id=e.id where e.name='karan' ";
                    SqlCommand cnd = new SqlCommand(query, connection);
                    connection.Open();


                    var result = cnd.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)
                    {
                        payments.net_pay = 43500;
                        Console.WriteLine("Updated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No record found for the given firstName");
                    }
                    return payments;
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
        
