using System;
using System.Data.SqlClient;

namespace ADO.Net
{
    class Program1
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = "Server=.;Database=CompanyDB;User Id=sa;Password=123;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                bool performOperation = true;

                while (performOperation)
                {
                    Console.WriteLine("What database operation do you want to perform? (INSERT, UPDATE, DELETE)");
                    string operation = Console.ReadLine().ToUpper();

                    switch (operation)
                    {
                        case "INSERT":
                            PerformInsert(connection);
                            break;
                        case "UPDATE":
                            PerformUpdate(connection);
                            break;
                        case "DELETE":
                            PerformDelete(connection);
                            break;
                        default:
                            Console.WriteLine("Invalid operation selected.");
                            break;
                    }

                    Console.WriteLine("Do you want to perform any other operations? (YES/NO)");
                    string continueOption = Console.ReadLine().ToUpper();
                    if (continueOption != "YES")
                    {
                        performOperation = false;
                    }
                }

                connection.Close();
                Console.WriteLine("Thanks for using the application.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void PerformInsert(SqlConnection connection)
        {
            Console.WriteLine("Enter the Employee Number: ");
            int empNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Employee Name: ");
            string empName = Console.ReadLine();
            Console.WriteLine("Enter DateOfBirth (yyyy-MM-dd): ");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter the City: ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter the DeptID: ");
            int depId = Convert.ToInt32(Console.ReadLine());

            string query = $"INSERT INTO EMPLOYEE (EmpID, EmpName, DateOfBirth, City, Email, DeptID) " +
                           $"VALUES ({empNum}, '{empName}', '{dob}', '{city}', '{email}', {depId})";

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            int rows = sqlCommand.ExecuteNonQuery();
            Console.WriteLine(rows + " rows are affected.");
        }

        static void PerformUpdate(SqlConnection connection)
        {
            // Implement the update logic similar to PerformInsert method
            Console.WriteLine("Update operation is not implemented yet.");
        }

        static void PerformDelete(SqlConnection connection)
        {
            // Implement the delete logic similar to PerformInsert method
            Console.WriteLine("Delete operation is not implemented yet.");
        }
    }
}
