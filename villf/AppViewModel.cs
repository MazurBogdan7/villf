using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;

namespace villf
{
    public class AppViewModel : baseVM
    {

        public SqlComponents Model = new SqlComponents();

        private string _Messeg;
        public string Messeg
        {
            get => _Messeg;
            set {

                _Messeg = value;
                OnPropertyChanged(nameof(Messeg));
            }
        }

        private string _login;
        public string login {
            get => _login;
            set {
                _login = value;
                OnPropertyChanged(nameof(login));
            }
        }
        private string _pasw;
        public string pasw {
            get => _pasw;
            set
            {
                _pasw = value;
                OnPropertyChanged(nameof(pasw));
            }

        }
        private string _mail;
        public string mail
        {
            get => _mail;
            set
            {
                _mail = value;
                OnPropertyChanged(nameof(mail));
            }

        }
        

        public bool checkLogPusw(string log_pasw)
        {
            bool check = true;
            if (log_pasw.IndexOf(' ') >= 0) check = false;
            if (log_pasw.IndexOf('-') >= 0) check = false;
            if (log_pasw.IndexOf('.') >= 0) check = false;
            if (log_pasw.IndexOf('#') >= 0) check = false;
            if (log_pasw.IndexOf('@') >= 0) check = false;
            if (log_pasw.IndexOf('&') >= 0) check = false;
            if (log_pasw.IndexOf('*') >= 0) check = false;
            if (log_pasw.IndexOf('^') >= 0) check = false;
            return check;
        }
        public bool checkMail(string chMail)
        {
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            if (Regex.IsMatch(chMail, pattern, RegexOptions.IgnoreCase))
            {
                
                return true;
            }
            else
            {
                return false;
            }


        }
        public void AddUser(object parameter)
        {
            int contr = 3;

            if (checkLogPusw(login) && checkLogPusw(pasw) && checkMail(mail)) {
                contr = Model.NewUser(login, pasw, mail);
                
            }
            else 
            {
                Messeg = "Убедитесь что ваши логин и пароль не содержат спец символы а ваш адрес введён коректно";
                
            }
                switch (contr)
                {
                    //add checks after adding commands
                case 0:
                    Messeg = "Вы успешно авторизованны";
                    break;
                case 1:
                    Messeg = "Ошибка в добавлении пользователя";
                    break;
                case 2:
                    Messeg = "Такой пользователь уже существует";
                    break;
                }
        }
        private ICommand _AddUs;
        public ICommand AddUs => _AddUs ?? (_AddUs = new RelayCommand(AddUser));

        public void CreateNewWindow()
        {
            MainVillf main = new MainVillf(_login)
            { 
                DataContext = new MainViewModel()
            };
            main.Show();
        }
        
        private void Enter(object parameter)
        {
            if (Model.EnterUs(_login, _pasw) == 1)
            {
                CreateNewWindow();
                Application.Current.MainWindow.Close();
            }
            else
            {
                Messeg = "Такого пользователя ненайдено. Попробуйте зарегестрироатся :)";
            }
        }
            
        private ICommand _EnterUser;
        public ICommand EnterUser => _EnterUser ?? (_EnterUser = new RelayCommand(Enter));



        

    }
}
