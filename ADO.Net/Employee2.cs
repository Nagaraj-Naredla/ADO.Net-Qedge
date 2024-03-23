using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADO.Net
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int DeptID { get; set; }
    }
    class Employee2
    {
        static void Main(string[] args)
        {
            // Method 2 Approach Non ActionQuery() that is SELECT Statement

            List<Employee> list = new List<Employee>();
            
            SqlConnection connection = new SqlConnection("server = .; user id = sa; password = 123; integrated security = true; database  = CompanyDB;");
            SqlCommand command = new SqlCommand("Select * from EMPLOY", connection);
            connection.Open();
            SqlDataReader dr  =  command.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.EmpId = Convert.ToInt32(dr["EmpId"]);
                    emp.EmpName = Convert.ToString(dr["EmpName"]);
                    emp.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
                    emp.City = Convert.ToString(dr["City"]);
                    emp.Email = Convert.ToString(dr["Email"]);
                    emp.DeptID = Convert.ToInt32(dr["DeptID"]);
                    list.Add(emp);
                   // Console.WriteLine($"{dr["EmpId"]} - {dr["EmpName"]} - {dr["DateOfBirth"]} - {dr["City"]} - {dr["Email"]} - {dr["DeptID"]}");
                }
                foreach (var emp in list) 
                {
                    
                    
                        Console.WriteLine($"Employee ID: {emp.EmpId}, Name: {emp.EmpName}, Date of Birth: {emp.DateOfBirth}, City: {emp.City}, Email: {emp.Email}, Department ID: {emp.DeptID}");
                   

                }
            }
            else 
            {
                Console.WriteLine("Records Not Found");
            }
            // dr.Close() for closing data Reader 
            dr.Close();
            connection.Close();

        }
    }
}
