﻿using System;
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
                            new Uri("/Users/Bogdan/source/repos/villf/villf/img_resurs/login_wotermark.gif", UriKind.Relative)
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
                            new Uri("/Users/Bogdan/source/repos/villf/villf/img_resurs/pas_wotermark.GIF", UriKind.Relative)
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

        public  RegisterWin()
        {
            InitializeComponent();
            
        }
        



    }
}
