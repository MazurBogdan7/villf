using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.ComponentModel;
namespace villf
{
    public static class AppViewModel //: INotifyPropertyChanged
    {
      
         public static RoutedEventHandler AddUs => AddUser;
        
        
        
       

        public static void AddUser(object sender, RoutedEventArgs e) 
        {
            
            
            SqlComponents Model = new SqlComponents();
           // string login = winR.login.Text;
           // string pasw = winR.passw.Text;

         //   Model.NewUser(login, pasw);
        }
        
    }
}
