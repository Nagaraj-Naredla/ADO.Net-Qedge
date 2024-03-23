using System;
using System.Data.SqlClient;

namespace ADO.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            // step 1 is to access database

            //  string connectionString = "server = .; user id = sa; password = 123;integrated security = true; database = CompanyDB ";
            //  SqlConnection con = new SqlConnection();
            //  con.ConnectionString = connectionString;
            // con.Open();
            try 
            {
                Console.WriteLine("Enter the Eno: ");
                int eno = Convert.ToInt32(Console.ReadLine());

                SqlConnection connection = new SqlConnection("server = .;user id = sa; password  = 123; integrated security = true; database = CompanyDB ");
                string query = "delete from Dept where deptID = "+eno;
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int i = command.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine(i + "one record is upadated");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
          
        }
    }
}
