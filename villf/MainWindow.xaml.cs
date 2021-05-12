using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace villf
{
    
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new AppViewModel();
        }
        private void RegistUs(object sender, RoutedEventArgs e)
        {
            RegisterWin reg = new RegisterWin();
            reg.Show();

        }
        
        void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {

            string objname = ((TextBox)sender).Name;
            if (objname == "login")
            {
                if (login.Text == "")
                {

                    ImageBrush textImageBrush = new ImageBrush();
                    textImageBrush.ImageSource =
                        new BitmapImage(
                            new Uri("/Users/Bogdan/source/repos/villf/villf/img_resurs/lw.png", UriKind.Relative)
                        );
                    textImageBrush.AlignmentX = AlignmentX.Left;
                    textImageBrush.Stretch = Stretch.None;

                    login.Background = textImageBrush;
                }

                else
                {
                    login.Background = null;

                }
            }
            else
            {
                if (passw.Text == "")
                {

                    ImageBrush textImageBrush = new ImageBrush();
                    textImageBrush.ImageSource =
                        new BitmapImage(
                            new Uri("/Users/Bogdan/source/repos/villf/villf/img_resurs/pw.png", UriKind.Relative)
                        );
                    textImageBrush.AlignmentX = AlignmentX.Left;
                    textImageBrush.Stretch = Stretch.None;

                    passw.Background = textImageBrush;
                }

                else
                {
                    passw.Background = null;

                }

            }
        }



    }
}
