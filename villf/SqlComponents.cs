﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace villf
{
    public class SqlComponents
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=films;Integrated Security=True";

        //the mettod check if such a user
        public int ChecUser(string login)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string S_user = "SELECT login FROM users WHERE login = @name";
            SqlCommand SearchU = new SqlCommand(S_user, connection);
            SqlParameter nameP = new SqlParameter("@name", login);
            SearchU.Parameters.Add(nameP);
            SqlDataReader read = SearchU.ExecuteReader();
            if (read.HasRows)
            {
                //this user already exists
                return 1;
            }
            else
            {
                return 0;
            }
            read.Close();

            connection.Close();
        }
        public int NewUser(string name, string pas) 
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string login = name;

            
            if (ChecUser(login) == 1)
            {
                //this user already exists
                return 2;
            }
            else 
            {
                

                SqlCommand NUser = new SqlCommand("numbUser", connection);
                NUser.CommandType = System.Data.CommandType.StoredProcedure;
                
                int id = (Int32)NUser.ExecuteScalar();
                
                

                string password = pas;
                string SAddU = "INSERT INTO users (numb_user, login , password) VALUES (@numb,@name,@pas) ";

                SqlCommand AddUser = new SqlCommand(SAddU, connection);

                
                

                SqlParameter idP = new SqlParameter("@numb", id);
                SqlParameter passP = new SqlParameter("@pas", password);
                SqlParameter loginP = new SqlParameter("@name",login);
                AddUser.Parameters.Add(loginP);
                AddUser.Parameters.Add(passP);
                AddUser.Parameters.Add(idP);
                int n = AddUser.ExecuteNonQuery();
                //error add user

                if (n <= 0) return 1;
            }
            


            connection.Close();
            return 0; 
            //user added successfully
        }
        public int EnterUs(string login) 
        {
            
            if (ChecUser(login) == 1)
            {
                //this user already exists
                return 1;
            }
            else { return 0; }

            
        }
    }
}
