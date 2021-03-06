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
        private string chekRadiobutton;
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
            NameUser.Text = login;
            DataContext = new MainViewModel();
            vm.prpremiere_films();
            this.Nfilms.DataContext = vm;
            vm.suggestedFilm(login);
            this.SugFilm.DataContext = vm;
            this.DataContext = new MainViewModel();


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
        public void TabFormatSearch(object sender, RoutedEventArgs e)
        {
            chekRadiobutton = null;
            Tabcontrol(6);
            formatSearch.DataContext = vm;
        }

        public void TabControlFilms(object sender, RoutedEventArgs e)
        {
            chekRadiobutton = null;
            Tabcontrol(7);
        }

        private void RadioButtonAgeChecked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            chekRadiobutton = pressed.Content.ToString();

        }

        private void FormatSearch(object sender, RoutedEventArgs e)
        {
            vm.FormatSearchFilm(year.Text, month.Text, country.Text, chekRadiobutton, time.Text, estim.Text, nameFilm.Text);

        }
        private void ControlFilm(object sender, RoutedEventArgs e)
        {
            vm.ADDFilms(C_year.Text, C_month.Text, C_country.Text, chekRadiobutton, C_time.Text, C_estim.Text, C_nameFilm.Text);

        }
    }
}
