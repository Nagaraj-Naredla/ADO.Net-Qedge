

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADO.Net
{
    class EmployeeCRUD
    {
        // INSERT/ SELECT / UPDATE/DELETE/ CREATE
        SqlConnection connection = new SqlConnection("server = .; user id = sa; password = 123; integrated security = true; database  = CompanyDB;");
        public List<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>();
            SqlCommand cmd = new SqlCommand(" sp_SelectEmp", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Employee emp = new Employee();
                    emp.EmpId = Convert.ToInt32(dr["EmpId"]);
                    emp.EmpName = Convert.ToString(dr["EmpName"]);
                    emp.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
                    emp.City = Convert.ToString(dr["City"]);
                    emp.Email = Convert.ToString(dr["Email"]);
                    emp.DeptID = Convert.ToInt32(dr["DeptID"]);
                    list.Add(emp);
                }
                dr.Close();
                connection.Close();
                return list;
            }
            else
            {
                return new List<Employee>();
            }
            

        }
        public string GetDeptName(int deptID)
        {
            return string.Empty;
        }
    }
}
