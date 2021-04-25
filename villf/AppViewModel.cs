using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.ComponentModel;
namespace villf
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       static public RoutedEventHandler AddUs => AddUser;
        string login;
        string pasw;
        
        
        public string Outputlogin
        {
            get => login;
            set
            {
                login = value;
                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Outputlogin)));
            }
        }
        public string Outputpas
        {
            get => pasw;
            set
            {
                pasw = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Outputpas)));
            }
        }

        public static void AddUser(object sender, RoutedEventArgs e) 
        {

            RegisterWin winR = new RegisterWin();
            SqlComponents Model = new SqlComponents();
            

            Model.NewUser(Outputlogin, Outputpas);
        }
        
    }
}
