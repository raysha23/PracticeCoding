using System;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;

namespace PracticeCoding
{
    internal class Program
    {
        static string connection = "Data Source=SHENRON\\SQLEXPRESS;Initial Catalog=UserAccounts;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("'1' : Create/Insert");
                Console.WriteLine("'2' : Read");
                Console.WriteLine("'0' : Exit");
                Console.Write("Enter: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InsertData();
                        break;
                    case "2":
                        ReadData();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }


            Console.ReadKey();
        }

        static void InsertData()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            string query = "INSERT INTO Accounts (AccountID, Username, Password) VALUES (@id, @username, @password)";

            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Data inserted successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data: {ex.Message}");
            }
        }

        static void ReadData()
        {
            string query = "SELECT * FROM Accounts";

            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("All Accounts:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["AccountID"]}, Username: {reader["Username"]}, Password: {reader["Password"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data: {ex.Message}");
            }
        }
        static void UpdateData()
        {
            
            using (SqlConnection con = new SqlConnection(connection))
                using(SqlCommand cmd = new SqlCommand())
            {

            }
        }
      
    }
}
