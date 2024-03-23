using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADO.Net
{
    class RegistrationModel1
    {
       
        public string Name { get; set; }
        public string Email{ get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Contact {  get; set; }
    }
   
    class LoginModel 
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    class Account
    {
        SqlConnection connection = new SqlConnection("server = .; user id = sa; password = 123; integrated security = true; database  = CompanyDB;");
        public int Register(RegistrationModel1 model)
        {
           //  string query = $"insert into Registration values('{model.Name}','{model.Email}','{model.Password}','{model.ConfirmPassword}','{model.Contact}')";
            string query = "INSERT INTO Registration (Name, Email, Password, ConfirmPassword, Contact) VALUES (@Name, @Email, @Password, @ConfirmPassword, @Contact)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Name", model.Name);
           cmd.Parameters.AddWithValue("@Email", model.Email);
           cmd.Parameters.AddWithValue("@Password", model.Password);
            cmd.Parameters.AddWithValue("@ConfirmPassword", model.ConfirmPassword);
            cmd.Parameters.AddWithValue("@Contact", model.Contact);

           
            connection.Open();
            int res = cmd.ExecuteNonQuery();
            connection.Close();
            return res;

        }
        public int Login(LoginModel model)
        {
            string query = $"select count(*) from Registration where Email= '{model.Email}' and Password = '{model.Password}'";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int res = Convert.ToInt32(cmd.ExecuteScalar ());
            connection.Close();
            return res;
        }
        public string GetUsername(string email)
        {
            string query = $"select Name from Registration where Email = '{email}'";
            SqlCommand cmd  = new SqlCommand(query , connection);
            connection.Open();
            string name = Convert.ToString(cmd.ExecuteScalar());
            connection.Close();
            return name;
        }



    }
    class Program3 
    {
        static void Main(string[] args)
        {
          Account account = new Account();
            Console.WriteLine("Welcome To Virtusa!");
            Console.WriteLine("Do You have Ceredentials? (Yes/No)");
            string LoginChoice = Console.ReadLine().ToLower();
            if (LoginChoice == "yes")
            {
                LoginModel model = new LoginModel();
                Console.WriteLine("Enter the Email ID: ");
                model.Email = Console.ReadLine();
                Console.WriteLine("Enter the Password: ");
                model.Password = Console.ReadLine();
                int i = account.Login(model);
                if(i > 0)
                {
                    Console.WriteLine("Welcome "+ account.GetUsername(model.Email));
                    EmployeeCRUD empInfo = new EmployeeCRUD();
                    List<Employee>emps = empInfo.GetEmployees();
                    if(emps.Count > 0)
                    {
                        foreach (var item in emps)
                        {
                            Console.WriteLine($"{item.EmpName} - {item.Email} - {item.City} - {item.DateOfBirth} - {item.DeptID}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Records found");
                    }
                

                }
                else
                {
                    Console.WriteLine("Login Failed!");
                }
                
            }
            else
            {
                RegistrationModel1 model = new RegistrationModel1();
                Console.WriteLine("Enter the Name: ");
                model.Name = Console.ReadLine();
                Console.WriteLine("Enter the Email:");
                model.Email = Console.ReadLine();
                Console.WriteLine("Enter the Password: ");
                model.Password = Console.ReadLine();
                ReEnter:
                Console.WriteLine("Confirm the Password: ");
                model.ConfirmPassword = Console.ReadLine();
                if(model.Password  != model.ConfirmPassword)
                {
                    Console.WriteLine("Password and ConfirmPassword Connot  Matched");
                    goto ReEnter;
                }
                Console.WriteLine("Enter the Contact Number: ");
                model.Contact = Console.ReadLine();
                int i = account.Register(model);
                if (i > 0)
                {
                    Console.WriteLine("Registration Completed Successfully!");
                }
                else
                {
                    Console.WriteLine("Registration Failed");
                }
            }
        }
    }
}
