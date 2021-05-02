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
        private static string _Messeg;
        public string Messeg
        {
            get { return _Messeg; }
            set {

                _Messeg = value;
                OnPropertyChanged("_Messeg");
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
        public static RoutedEventHandler AddUs => AddUser;

        public static void AddUser(object sender, RoutedEventArgs e)
        {

            SqlComponents Model = new SqlComponents();
            int contr = Model.NewUser(_login, _pasw);
            switch (contr)
            {
                case 0:
                    _Messeg = "Вы успешно авторизованны";
                    break;


            }

        }


        private void Enter(object parameter)
        {
            Application.Current.MainWindow.Close();
            MainVillf main = new MainVillf();
            main.Show();
        }
        private ICommand _EnterUser;
        public ICommand EnterUser => _EnterUser ?? (_EnterUser = new RelayCommand(Enter));





    }
}
