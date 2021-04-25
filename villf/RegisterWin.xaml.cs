using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace villf
{
 
    public partial class RegisterWin : Window
    {
      

        public RegisterWin()
        {
            InitializeComponent();
           
            
        }

        private void ClL(object sender, MouseButtonEventArgs e)
        {
            login.Text = null;
        }
        private void ClP(object sender, MouseButtonEventArgs e)
        {
            passw.Text = null;
        }
      
        
    }
}
