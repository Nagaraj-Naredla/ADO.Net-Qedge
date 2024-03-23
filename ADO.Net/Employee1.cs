using System;
using System.Data.SqlClient;

namespace ADO.Net
{
    class Employee1
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the Employee Number: ");
                int empNum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Employee Name: ");
                string empName = Console.ReadLine();
                Console.WriteLine("Enter DateOfBirth: ");
                DateTime dob = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the City: ");
                string city = Console.ReadLine();
                Console.WriteLine("Enter Email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter the DeptID: ");
                int depId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"{empNum}\n {empName}\n{dob}\n{city}\n{email}\n{depId}");

                SqlConnection connection = new SqlConnection("server = .; user id = sa; password = 123;integrated security = true; database = CompanyDB ");
                string query = $"insert into EMPLOY values({empNum},'{empName}','{dob}','{city}','{email}',{depId})";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                connection.Open();
                int rows = sqlCommand.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine(rows+" rows are affected:");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
           
        }
    }
}
