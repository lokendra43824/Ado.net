using EmployeePayrollService;
using System;
using System.Data;
using System.Data.SqlClient;

public class EmployeeRepo
{
    public static string connectionString = @"Data Source=(localDB)\MSSQLLocalDB;Initial Catalog=PayRollAssignment;Integrated Security=True";
    static SqlConnection connection = new SqlConnection(connectionString);
    public void GetAllEmployee(string query)
    {
        try
        {
            EmployeePayroll employeePayroll = new EmployeePayroll();
            using (connection)
            {
                 

                // string query= @"select* from Employee_payroll where start_Date between CAST('2019-01-01' as date) and GETDATE()";
                SqlCommand cnd = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader dr = cnd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        employeePayroll.EmployeeID = dr.GetInt32(0);
                        employeePayroll.EmployeeName = dr.GetString(1);
                        employeePayroll.StartDate = dr.GetDateTime(2);
                        employeePayroll.Gender = Convert.ToChar(dr.GetString(3));
                        employeePayroll.Address = dr.GetString(4);
                        employeePayroll.PhoneNumber = dr.GetString(5);

                        Console.WriteLine(employeePayroll.EmployeeID + "  " + employeePayroll.EmployeeName + "  " + employeePayroll.StartDate + "  " + employeePayroll.Gender + "  " + employeePayroll.Address + "  " + employeePayroll.PhoneNumber);
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

    public bool AddEmployeeDetailsUsingStoredProcedure(EmployeePayroll employee)
    {
        try
        {

            using (connection)
            {

                SqlCommand cnd = new SqlCommand("SpAddEmployeeDetails", connection);
                cnd.CommandType = CommandType.StoredProcedure;
                cnd.Parameters.AddWithValue("@EmpName", employee.EmployeeName);
                cnd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cnd.Parameters.AddWithValue("@Gender", employee.Gender);
                cnd.Parameters.AddWithValue("@Address", employee.Address);
                cnd.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
                connection.Open();

                var result = cnd.ExecuteNonQuery();
                connection.Close();

                if (result != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


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
   
    public bool UpdateEmployeeAddressUsingStoredProcedure(string name, string address)
    {
        try
        {

            using (connection)
            {

                SqlCommand cnd = new SqlCommand("spUpdateSalary", connection);
                cnd.CommandType = CommandType.StoredProcedure;
                cnd.Parameters.AddWithValue("@address", address);
                cnd.Parameters.AddWithValue("@name", name);

                connection.Open();

                var result = cnd.ExecuteNonQuery();
                connection.Close();

                if (result != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


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
       public void RetrieveAllSalaries()
        {
            try
            {
                Transactions payments = new Transactions();
                using (connection)
                {
                    string query = @"select * from payments";
                    SqlCommand cnd = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader dr = cnd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        Console.WriteLine("Id" + " " + "Basic_pay" + " " + "Deductions" + " " + "Taxable_Pay" + " " + "Tax" + " " + "Net_pay" + "\n");
                        while (dr.Read())
                        {
                            payments.id = dr.GetInt32(0);
                            payments.basicPay = dr.GetDecimal(1);
                            payments.deductions = dr.GetDecimal(2);
                            payments.taxable_pay = dr.GetDecimal(3);
                            payments.tax = dr.GetDecimal(4);
                            payments.net_pay = dr.GetDecimal(5);


                            Console.WriteLine(payments.id + "  " + payments.basicPay + "  " + payments.deductions + "  " + payments.taxable_pay + " " + payments.tax + "  " + payments.net_pay);
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
    public void DeleteAnEmployee()
    {
        try
        {

            using (connection)
            {
                Transactions payments = new Transactions();
                string query = @"delete from Employee_payroll where id=9";
                SqlCommand cnd = new SqlCommand(query, connection);
                connection.Open();


                var result = cnd.ExecuteNonQuery();

                connection.Close();

                if (result != 0)
                {

                    Console.WriteLine("Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("No record found for the given id ");
                }

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
     
