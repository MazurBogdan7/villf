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

    public partial class MainVillf : Window
    {
        static int newIndex;
        void Tabcontrol(int n)
        {

            menuTab.SelectedIndex = n-1;
            newIndex = menuTab.SelectedIndex;
        }
        private MainViewModel vm;
        public MainVillf(string login)
        {
            vm = new MainViewModel();
            InitializeComponent();

            vm.prpremiere_films();
            this.Nfilms.DataContext = vm;
            this.DataContext = new MainViewModel();
            
            NameUser.Text = login;

            
        }
        void TBchangSearch(object sender, TextChangedEventArgs e)
        {
            vm = new MainViewModel();   
            
            if (search.Text == "")
            {

                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri("/Users/Bogdan/source/repos/villf/villf/img_resurs/SearchW.png", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;

                search.Background = textImageBrush;

                Tabcontrol(1);
            }

            else
            {
                search.Background = null; 

                Tabcontrol(2);

                vm.checkFilm(search.Text);
                this.filmlist.DataContext = vm;
               


            }
        }
       
            public void TabMain(object sender, RoutedEventArgs e)
        {
            Tabcontrol(1);
        }
        public void filmList_selectionChenged(object sender, SelectionChangedEventArgs e)
        {
            Tabcontrol(4);
            var item = (ListBox)sender;
            vm.info_film(item.SelectedItem);
            this.film.DataContext = vm;

        }
        public void TabUser(object sender, RoutedEventArgs e)
        {
            Tabcontrol(3);

        }


    }
}
