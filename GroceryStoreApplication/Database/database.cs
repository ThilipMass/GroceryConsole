using System;
using System.Data;
using GroceryStoreApplication;
using Microsoft.Data.SqlClient;

class DbConnection
{
    
    public static void DisplayCustomerDetails(string id)
    {
         string input = id;
        string newID = input.Substring(3);
        SqlConnection connection = new SqlConnection(Program.connectionString);
        try
        {
            connection.Open();
            // Create a SQL command
            SqlCommand command = new SqlCommand("SELECT * from CustomerDetails where customerID="+newID, connection);

            // Execute the command and read data
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine($"-----------------------------------------------");
            while (reader.Read())
            {
               // System.Console.WriteLine(reader["customerID"]);
                //Name, mobile, MailID, WalletBalance
                int customerID = reader.GetInt32(0);
                string Name = reader.GetString(1);
                decimal mobile = reader.GetDecimal(2);
                string mailID = reader.GetString(3);
                decimal WalletBalance = reader.GetDecimal(4);
                //Console.WriteLine($"CustomerID : {customerID}\n name : {name}\n  Mobile number : {mobileNumber}\nMailID :{mailID}\nBalance : {balance}\n");
                Console.WriteLine($"CustomerID : {customerID} name : {Name} Mobile number : {mobile}  MailID :{mailID} Balance : {WalletBalance}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            connection.Close();
        }
    }
    
    public static void DisplayProduct()
    {
        SqlConnection connection = new SqlConnection(Program.connectionString);
        try
        {
            connection.Open();
            // Create a SQL command
            SqlCommand command = new SqlCommand("SELECT * from Products", connection);

            // Execute the command and read data
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine($"********ProductDetails*******");
            Console.WriteLine($"-------------------------------------------------------------------------");
            Console.WriteLine($"|{"ProductID",-12}|{"ProductName",-22}|{"QuantityAvailable",-18}|{"PricePerQuantity",-16}|");
            Console.WriteLine($"-------------------------------------------------------------------------");
            while (reader.Read())
            {
                int productID = reader.GetInt32(0);
                String productName = reader.GetString(1);
                int productQuantity = reader.GetInt32(2);
                decimal productPrice = reader.GetDecimal(3);
                Console.WriteLine($"|{productID,-12}|{productName,-22}|{productQuantity,-18}|{productPrice,-16}|");
                Console.WriteLine($"-------------------------------------------------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            connection.Close();
        }
    }
    public static void UpdatUserDetails(string name,string mobile, string mailId, double walletBalance)
    {

        // SqlConnection connection = new SqlConnection(Program.connectionString);
        string query = @"INSERT INTO CustomerDetails (Name,mobile, MailID, WalletBalance) 
                            VALUES (@Name, @Mobile, @MailID, @WalletBalance)";

        using (SqlConnection connection = new SqlConnection(Program.connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);

            // Add parameters to the command
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Mobile", mobile);
            command.Parameters.AddWithValue("@MailID", mailId);
            command.Parameters.AddWithValue("@WalletBalance", walletBalance);

            try
            {
                connection.Open();
                // Create a SQL command
                // SqlCommand command = new SqlCommand("insert into CustomerDetails (Name,FatherName,Gender,mobile,DOB,MailID,WalletBalance) Values (@name,)", connection);
                // SqlCommand command = new SqlCommand(query, connection);

                // Execute the command and read data
                SqlDataReader reader = command.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
