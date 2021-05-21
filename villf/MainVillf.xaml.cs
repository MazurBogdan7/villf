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

            menuTab.SelectedIndex = n - 1;
            newIndex = menuTab.SelectedIndex;

        }
        private MainViewModel vm;
        public MainVillf(string login)
        {
            vm = new MainViewModel();
            InitializeComponent();
            DataContext = new MainViewModel();
            vm.prpremiere_films();
            this.Nfilms.DataContext = vm;
            vm.suggestedFilm();
            this.SugFilm.DataContext = vm;
            this.DataContext = new MainViewModel();

            NameUser.Text = login;
            this.NameUser.DataContext = vm;
            




        }
        void TBchangSearch(object sender, TextChangedEventArgs e)
        {
           vm.cleaningSearch();

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
        private void Nfilms_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (ListBox)sender;
            if (item.SelectedItem != null)
            {
                Tabcontrol(4);

                vm.info_film(item.SelectedItem);

                this.film.DataContext = vm.infofilms;
                this.people.DataContext = vm;
                this.points.DataContext = vm;
                this.UserPoint.DataContext = vm;
               

            }
        }
        public void TabUser(object sender, RoutedEventArgs e)
        {
            Tabcontrol(3);

        }
        public void TabEstimations(object sender, RoutedEventArgs e)
        {
            Tabcontrol(5);
        }

    }
}
