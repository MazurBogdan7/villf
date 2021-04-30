using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.ComponentModel;
namespace villf
{
    public class AppViewModel : baseVM
    {
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


           
            

          Model.NewUser(_login, _pasw);
        }
        
    }
}
