using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace villf
{
    public class SqlComponents
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=films;Integrated Security=True";
        public int NewUser(string name, string pas) 
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string login = name;

            //the command check if such a user

            string S_user = "SELECT login FROM users WHERE login = @name";
            SqlCommand SearchU = new SqlCommand(S_user, connection);
            SqlParameter nameP = new SqlParameter("@name", login);
            SearchU.Parameters.Add(nameP);
            SqlDataReader read = SearchU.ExecuteReader();
            if (read.HasRows)
            {
                //this user already exists
                return 2;
            }
            else 
            {
                read.Close();
                string password = pas;
                string SAddU = "INSERT INTO users (login , password) VALUES (@name,@pas) ";
                SqlCommand AddUser = new SqlCommand(SAddU, connection);
                SqlParameter passP = new SqlParameter("@pas", password);
                SqlParameter loginP = new SqlParameter("@name",login);
                AddUser.Parameters.Add(loginP);
                AddUser.Parameters.Add(passP);
                int n = AddUser.ExecuteNonQuery();
                //error add user

                if (n <= 0) return 1;
            }
            


            connection.Close();
            return 0; 
            //user added successfully
        }

    }
}
