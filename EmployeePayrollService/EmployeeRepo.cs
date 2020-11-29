﻿using EmployeePayrollService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class EmployeeRepo
{
    public static string connectionString = @"Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=PayRollAssignment;Integrated Security=True";
    static SqlConnection connection = new SqlConnection(connectionString);


    public List<EmployeePayroll> GetAllEmployee(string query)
    {
        try
        {
            List<EmployeePayroll> list = new List<EmployeePayroll>();

            using (connection)
            {

                SqlCommand cnd = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader dr = cnd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EmployeePayroll employeePayroll = new EmployeePayroll();
                        employeePayroll.id = dr.GetInt32(0);
                        employeePayroll.name = dr.GetString(1);
                        employeePayroll.startDate = dr.GetDateTime(2);
                        employeePayroll.gender = Convert.ToChar(dr.GetString(3));
                        employeePayroll.Address = dr.GetString(4);
                        employeePayroll.phoneNumber = dr.GetString(5);

                        Console.WriteLine(employeePayroll.id + "  " + employeePayroll.name + "  " + employeePayroll.startDate + "  " + employeePayroll.gender + "  " + employeePayroll.Address + "  " + employeePayroll.phoneNumber);
                        Console.WriteLine("");
                        list.Add(employeePayroll);
                    }
                }
                else
                {
                    Console.WriteLine("No DAta found");
                }
                dr.Close();
                connection.Close();
                return list;
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
                string query = @"update payments set payments.net_pay=43500 from payments p inner join Employee_payroll e on p.id=e.id where e.name='Dhoni' ";
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


    public Payments UpdateEmployeeSalaryUsingStoredProcedure(string name, double salary)
    {
        try
        {


            using (connection)
            {
                Payments payments = new Payments();
                SqlCommand cnd = new SqlCommand("sp_UpdateSalary", connection);
                cnd.CommandType = CommandType.StoredProcedure;
                cnd.Parameters.AddWithValue("@salary", salary);
                cnd.Parameters.AddWithValue("@name", name);

                connection.Open();
                SqlDataReader dr = cnd.ExecuteReader();


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        payments.net_pay = dr.GetDecimal(1);
                    }
                }
                connection.Close();
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
    public Payments addEmployee(EmployeePayroll employee)
    {
        try
        {

            using (connection)
            {

                SqlCommand cnd = new SqlCommand("SpAddEmployeeDetails", connection);
                cnd.CommandType = CommandType.StoredProcedure;
                cnd.Parameters.AddWithValue("@EmpName", employee.name);
                cnd.Parameters.AddWithValue("@StartDate", employee.startDate);
                cnd.Parameters.AddWithValue("@Gender", employee.gender);
                cnd.Parameters.AddWithValue("@Address", employee.Address);
                cnd.Parameters.AddWithValue("@phoneNumber", employee.phoneNumber);
                connection.Open();

                var result = cnd.ExecuteReader();
                Payments payments = new Payments();
                if (result.HasRows)
                {
                    if (result.Read())
                    {

                        payments.id = result.GetInt32(0);
                        payments.basicPay = result.GetDecimal(1);
                        payments.deductions = result.GetDecimal(2);
                        payments.taxable_pay = result.GetDecimal(3);
                        payments.tax = result.GetDecimal(4);
                        payments.net_pay = result.GetDecimal(5);

                    }
                }
                result.Close();
                connection.Close();
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