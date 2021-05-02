using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
namespace villf
{
    public class AppViewModel : baseVM
    {
        private string _Messeg;
        public string Messeg
        {
            get => _Messeg;
            set {

                _Messeg = value;
                OnPropertyChanged(nameof(Messeg));
            }
        }

        private static string _login;
        public string login {
            get => _login;
            set {
                _login = value;
                OnPropertyChanged(nameof(login));
            }
        }
        private static string _pasw;
        public string pasw {
            get => _pasw;
            set
            {
                _pasw = value;
                OnPropertyChanged(nameof(pasw));
            }

        }
        static SqlComponents Model = new SqlComponents();
        public static RoutedEventHandler AddUs => AddUser; //remake the event into a command sometime later

        public static void AddUser(object sender, RoutedEventArgs e)
        {

            
            int contr = Model.NewUser(_login, _pasw);
            switch (contr)
            {
                //add checks after adding commands
                case 0:
                   // Messeg = "Вы успешно авторизованны";
                    break;


            }

        }


        private void Enter(object parameter)
        {
            if (Model.EnterUs(_login) == 1)
            {
                MainVillf main = new MainVillf();
                main.Show();
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
