using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.ObjectModel;


namespace villf
{
    public class SqlComponents
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=films;Integrated Security=True";

        //the mettod check if such a user
        public int ChecUser(string login, string pasword)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string S_user = "SELECT login FROM users WHERE login = @name and password = @pas";
            SqlCommand SearchU = new SqlCommand(S_user, connection);
            SqlParameter nameP = new SqlParameter("@name", login);
            SqlParameter pasP = new SqlParameter("@pas", pasword);
            SearchU.Parameters.Add(nameP);
            SearchU.Parameters.Add(pasP);
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
        public int NewUser(string name, string pas, string mail)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string login = name;


            if (ChecUser(login,pas) == 1)
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
                string SAddU = "INSERT INTO users (numb_user, login , password, mail) VALUES (@numb,@name,@pas,@mail) ";

                SqlCommand AddUser = new SqlCommand(SAddU, connection);




                SqlParameter idP = new SqlParameter("@numb", id);
                SqlParameter passP = new SqlParameter("@pas", password);
                SqlParameter loginP = new SqlParameter("@name", login);
                SqlParameter mailP = new SqlParameter("@mail", mail);

                AddUser.Parameters.Add(loginP);
                AddUser.Parameters.Add(passP);
                AddUser.Parameters.Add(idP);
                AddUser.Parameters.Add(mailP);
                int n = AddUser.ExecuteNonQuery();
                //error add user

                if (n <= 0) return 1;
            }



            connection.Close();
            return 0;
            //user added successfully
        }
        public int EnterUs(string login,string pas)
        {

            if (ChecUser(login, pas) == 1)
            {
                //this user already exists
                return 1;
            }
            else { return 0; }


        }
        public string GetMailUser(string nameUser)
        {
            string mail = "";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string user = "SELECT mail FROM users WHERE login = @name";
            SqlCommand SearchM = new SqlCommand(user, connection);
            SqlParameter nameP = new SqlParameter("@name", nameUser);
            SearchM.Parameters.Add(nameP);
            SqlDataReader read = SearchM.ExecuteReader();

            if (read.HasRows)
            {
                if (read.Read()) mail = read.GetString(0);
            }
            read.Close();
            connection.Close();
            return mail;
        }
        public List<string> ChFilm(string name)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string S_film = "SELECT name_film FROM films WHERE name_film like @name+'%'";
            SqlCommand SearchF = new SqlCommand(S_film, connection);
            SqlParameter nameP = new SqlParameter("@name", name);
            SearchF.Parameters.Add(nameP);
            SqlDataReader read = SearchF.ExecuteReader();

            List<string> films = new List<string>();

            if (read.HasRows)
            {


                string f;
                while (read.Read())
                {

                    f = (string)read.GetValue(0);
                    films.Add(f);


                }


            }

            read.Close();
            connection.Close();
            return films;
        }
        public List<string> getNamefilm(string newfilms)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand GetPrFilms = new SqlCommand(newfilms, connection);
            SqlDataReader read = GetPrFilms.ExecuteReader();
            List<string> films = new List<string>();
            if (read.HasRows)
            {
                string f;
                while (read.Read())
                {
                    f = (string)read.GetValue(0);
                    films.Add(f);
                }
            }
            read.Close();
            connection.Close();
            return films;
        }
        public List<byte[]> getPosterFilm(string poster_films)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand GetPosterFilms = new SqlCommand(poster_films, connection);
            SqlDataReader read = GetPosterFilms.ExecuteReader();
            List<byte[]> posters = new List<byte[]>();
            if (read.HasRows)
            {

                while (read.Read())
                {
                    byte[] f = (byte[])read.GetValue(0);

                    posters.Add(f);
                }
            }
            read.Close();
            connection.Close();
            return posters;
        }

        public List<byte[]> Films_img(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string poster_films = "SELECT poster FROM films WHERE name_film like @name+'%'";
            SqlCommand GetPosterFilms = new SqlCommand(poster_films, connection);
            SqlParameter nameP = new SqlParameter("@name", name);
            GetPosterFilms.Parameters.Add(nameP);
            SqlDataReader read = GetPosterFilms.ExecuteReader();
            List<byte[]> posters = new List<byte[]>();
            if (read.HasRows)
            {

                while (read.Read())
                {
                    byte[] f = (byte[])read.GetValue(0);

                    posters.Add(f);
                }
            }
            read.Close();
            connection.Close();
            return posters;
        }
        public List<string> premiereFilms()
        {
            string newfilms = "select name_film from films where MONTH(premiere_date) = MONTH(getdate()) and YEAR(premiere_date) = YEAR(GETDATE())";
            return getNamefilm(newfilms);
        }
        public List<byte[]> premiereFilms_img()
        {

            string poster_films = "select poster from films where MONTH(premiere_date) = MONTH(getdate()) and YEAR(premiere_date) = YEAR(GETDATE())";
            return getPosterFilm(poster_films);
        }
        public List<object> suggestedFilm()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string randFilms = "select top 7 name_film, poster from films ORDER BY NEWID()";
            SqlCommand GetPrFilms = new SqlCommand(randFilms, connection);
            SqlDataReader read = GetPrFilms.ExecuteReader();
            List<object> films = new List<object>();
            if (read.HasRows)
            {
                string f;
                byte[] p;
                while (read.Read())
                {
                    f = (string)read.GetValue(0);
                    p = (byte[])read.GetValue(1);
                    films.Add(f);
                    films.Add(p);
                }
            }
            read.Close();
            connection.Close();
            return films;

        }

        public int[] checkRev(string login, string nameFilm)
        {
            int[] nRev_est = new int[2];
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string checkRev = "checkRev";

            SqlCommand checkRevCommand = new SqlCommand(checkRev, connection);
            checkRevCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter loginP = new SqlParameter
            {
                ParameterName = "@login",
                Value = login

            };
            SqlParameter nameFilmP = new SqlParameter
            {
                ParameterName = "@nameFilm",
                Value = nameFilm

            };

            checkRevCommand.Parameters.Add(loginP);
            checkRevCommand.Parameters.Add(nameFilmP);
            SqlDataReader read = checkRevCommand.ExecuteReader();
            
            if (read.HasRows)
            {
                if (read.Read())
                {
                  nRev_est[0] = read.GetInt32(0); // 0 - review number
                  nRev_est[1] = read.GetInt32(3); // 1 - estimation in review
                }
            }
            else


            read.Close();
            connection.Close();
            return nRev_est;
        }
        public int newEstim(string login, string nameFilm,int estim)
        {
            int error = 0;
            const int UPDATE_ERR = 1;
            const int INSERT_ERR = 2;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            
            string insertEst = "neEstim";
            string updateEst = "updateEstim";
            

            SqlParameter loginP = new SqlParameter
            {
                ParameterName = "@login",
                Value = login

            };    
            SqlParameter nameFilmP = new SqlParameter
            {
                ParameterName = "@nameFilm",
                Value = nameFilm

            };      
            SqlParameter estimP = new SqlParameter
            {
                ParameterName = "@estim",
                Value = estim

            };

            int[] nRev_est = checkRev(login,nameFilm);



            int nRev = nRev_est[0];
            
            if (nRev != 0)
            {
                
                SqlCommand updateRevCommand = new SqlCommand(updateEst, connection);
                updateRevCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter estmP = new SqlParameter
                {
                    ParameterName = "@numbRev",
                    Value = nRev

                };
                

                updateRevCommand.Parameters.Add(estmP);
                updateRevCommand.Parameters.Add(loginP);
                updateRevCommand.Parameters.Add(nameFilmP);
                updateRevCommand.Parameters.Add(estimP);
                
                //error update
                if (updateRevCommand.ExecuteNonQuery() == 0) error = UPDATE_ERR;
                

            }
            else
            {
                
                SqlCommand newRevCommand = new SqlCommand(insertEst, connection);
                newRevCommand.CommandType = System.Data.CommandType.StoredProcedure;

                newRevCommand.Parameters.Add(loginP);
                newRevCommand.Parameters.Add(nameFilmP);
                newRevCommand.Parameters.Add(estimP);

                //error insert 
                if(newRevCommand.ExecuteNonQuery() == 0) error = INSERT_ERR;
               
               
            }

            
            connection.Close();
            return error;
        }
        public float UpdateFilmEstim(string nameFilm) 
        {
            float estimation = 0;
            int error;
            const int UPDATE_ERR = 1; 
            List<int> usersEstimations = new List<int>();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string GetEstimations = "GetEstimationsFilm";
            string SetFilmEstimation = "newFilmEstim";
            SqlCommand GetEstimFilm = new SqlCommand(GetEstimations, connection);
            GetEstimFilm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter nameFilmP = new SqlParameter("@nameFilm", nameFilm);
            GetEstimFilm.Parameters.Add(nameFilmP);
            SqlDataReader read = GetEstimFilm.ExecuteReader();
            if (read.HasRows) 
            {
                while (read.Read()) 
                {
                    usersEstimations.Add(read.GetInt32(0));
                }
            }
            read.Close();
            GetEstimFilm.Parameters.Clear();

            if (usersEstimations.Count != 0)
            estimation = numerical_methods.average_rating(usersEstimations, usersEstimations.Count);

            SqlCommand setEstim = new SqlCommand(SetFilmEstimation,connection);
            setEstim.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter estimFilm = new SqlParameter("@estim", estimation);
            setEstim.Parameters.Add(estimFilm);
            setEstim.Parameters.Add(nameFilmP);
            if (setEstim.ExecuteNonQuery() == 0) error = UPDATE_ERR ;





            connection.Close();
            return estimation;
        }
        public ObservableCollection<estimationsUser> GetEstim_User(string login)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string EstimsUser = "select reviews.estimation,name_film from reviews join films on reviews.numb_film = films.numb_film join users on reviews.numb_user = users.numb_user where login = @name";
            SqlCommand GetEstimsUser = new SqlCommand(EstimsUser, connection);
            SqlParameter nameP = new SqlParameter("@name", login);
            GetEstimsUser.Parameters.Add(nameP);
            SqlDataReader read = GetEstimsUser.ExecuteReader();
            ObservableCollection<estimationsUser> ListEstms = new ObservableCollection<estimationsUser>();
            if (read.HasRows)
            { 
                while (read.Read())
                {
                    ListEstms.Add(new estimationsUser(read.GetString(1),read.GetInt32(0)));

                }
            
            }

            read.Close();
            connection.Close();
            return ListEstms;
        }
        public ObservableCollection<film> GetInfoFilm(string nameFilm) 
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string inf_film = "infFilm";
            SqlCommand GetInfoFilm = new SqlCommand(inf_film,connection);
            GetInfoFilm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter nameP = new SqlParameter {
                ParameterName = "@name",
                Value = nameFilm

            }; 
            GetInfoFilm.Parameters.Add(nameP);
            SqlDataReader read = GetInfoFilm.ExecuteReader();
            ObservableCollection<film> ListInfoFilm = new ObservableCollection<film>();
            string NthString = "";
            float i = 0;
            if (read.HasRows)
            {
                while (read.Read())
                {
                    string namefilm = read.GetString(0) ;
                    byte[] poster = (byte[])read.GetValue(1) ?? new byte[] { };
                    int year = (int)read.GetValue(2);
                    string country = read.GetString(3) ?? NthString;
                    string style = read.GetString(4) ?? NthString;
                    int budget = Convert.ToInt32(read.GetValue(5));
                    string date_premiere = Convert.ToString( read.GetValue(6)) ?? NthString;
                    string time = Convert.ToString(read.GetValue(7)) ?? NthString;
                    string MPAA_rating = read.GetString(8) ?? NthString;
                    string rus_rating = read.GetString(9) ?? NthString;
                    float estimation = read.GetValue(10) == DBNull.Value ? 0: (float)Convert.ToDouble(read.GetValue(10));
                    string company = read.GetString(11) ?? NthString;

                    ListInfoFilm.Add(new film
                    (
                        namefilm,
                        poster,
                        year,
                        estimation,
                        country,
                        style,
                        date_premiere,
                        time,
                        budget,
                        rus_rating,
                        company
                    ));
                }
                
            }
            read.Close();
            connection.Close();
            return ListInfoFilm;
        }

        public ObservableCollection<creator> GetInfoCreators(string nameFilm)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string get_creators_film = "GetCreatorsFilm";
            SqlCommand GetcreatorsFilm = new SqlCommand(get_creators_film, connection);
            GetcreatorsFilm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter nameP = new SqlParameter
            {
                ParameterName = "@nameFilm",
                Value = nameFilm

            };
            GetcreatorsFilm.Parameters.Add(nameP);
            SqlDataReader read = GetcreatorsFilm.ExecuteReader();
            ObservableCollection<creator> ListCreators = new ObservableCollection<creator>();
            string NthString = "";
            if (read.HasRows)
            {
                while (read.Read())
                {
                    string lastname = read.GetValue(4) == DBNull.Value ? NthString : (string)read.GetValue(4);
                    ListCreators.Add(new creator(read.GetString(0),read.GetString(1), read.GetString(2), read.GetString(3), lastname));

                }
            }

            read.Close();
            connection.Close();
            return ListCreators;
        }
    }
}
