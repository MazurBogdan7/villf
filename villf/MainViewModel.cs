using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace villf
{
    class MainViewModel :baseVM
    {
        static SqlComponents Model = new SqlComponents();

        string log;
        public string login { get=>log; set { log = value; } }

        //public class film
        //{
            
        //}

        private ObservableCollection<film> _films = new ObservableCollection<film>();
        public ObservableCollection<film> films
            {
                get => _films;
                set
                {
                    _films = value;
                    OnPropertyChanged(nameof(films));
                }
            }

        private ObservableCollection<film> _new_films = new ObservableCollection<film>();
        public ObservableCollection<film> new_films
        {
            get => _new_films;
            set
            {
                _new_films = value;
                OnPropertyChanged(nameof(new_films));
            }
        }
        private ObservableCollection<film> _infofilms = new ObservableCollection<film>();
        public ObservableCollection<film> infofilms
        {
            get => _infofilms;
            set
            {
                _infofilms = value;
                OnPropertyChanged(nameof(infofilms));
            }
        }
        public List<string> filmsNams = new List<string>();
        public List<byte[]> posters = new List<byte[]>();
        public void checkFilm(string _Search)
        {
                

            if (_Search != null) {
                int i = 0;
                posters = Model.Films_img(_Search);
                filmsNams = Model.ChFilm(_Search);
                foreach (var entry in filmsNams)
                {

                    films.Add(new film(entry,posters[i]));
                }
            }

        }

        public void prpremiere_films() 
        {
            int i = 0;
            filmsNams = Model.premiereFilms();
            posters = Model.premiereFilms_img();
            foreach (var entry in filmsNams )
            {

                new_films.Add(new film(entry, posters[i]));
                i++;
            }

        }
        private film _selectedFilm;
        public film selectedFilm
        {
            get => _selectedFilm;
            set
            {

                _selectedFilm = value;
                OnPropertyChanged(nameof(selectedFilm));
            }
        }
        public void info_film(object item) 
        {
            
            film f = (film)item;
            if (f != null)
            {
                string name_film = f.name;
                infofilms = Model.GetInfoFilm(name_film);
            }
        }

        public void outpInformUser(object parameter)
        {
                

        }

        private ICommand _output;

        public ICommand output => _output ?? (_output = new RelayCommand(outpInformUser));

        
    }
}
