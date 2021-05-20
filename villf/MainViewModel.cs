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

        private string _login;
        public string login 
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(login));
            }

        }

        

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
        private ObservableCollection<film> _Sugfilms = new ObservableCollection<film>();
        public ObservableCollection<film> Sugfilms
        {
            get => _Sugfilms;
            set
            {
                _Sugfilms = value;
                OnPropertyChanged(nameof(Sugfilms));
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
        private ObservableCollection<creator> _infoCreators = new ObservableCollection<creator>();
        public ObservableCollection<creator> infoCreators
        {
            get => _infoCreators;
            set
            {
                _infoCreators = value;
                OnPropertyChanged(nameof(infoCreators));
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
                    films.Add(new film(entry,posters[i],0,0,"","","","",0,"",""));
                    i++;
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

                new_films.Add(new film(entry, posters[i], 0, 0, "", "", "", "", 0, "", ""));
                i++;
            }

        }
        public List<object> filmsObj = new List<object>();
        public void suggestedFilm()
        {
            
            int i = 0;
            int j = 1;
            int k = 1;
            int nfilms;
            filmsObj = Model.suggestedFilm();
            nfilms = filmsObj.Count / 2;
            while (k <= nfilms)
            {
                Sugfilms.Add(new film((string)filmsObj[i], (byte[])filmsObj[j], 0, 0, "", "", "", "", 0, "", ""));
                i += 2;
                j += 2;
                k++;
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
        private int _userEstim;
        public int userEstim
        {
            get => _userEstim;
            set
            {

                _userEstim = value;
                OnPropertyChanged(nameof(userEstim));
            }
        }

        public void newEstimation(object namber)
        {
            int[] resEstim = new int[2];
            Model.newEstim(login, selectedFilm.name, Convert.ToInt32(namber));
            resEstim = Model.checkRev(login, selectedFilm.name);
            userEstim = resEstim[1];
        }
        private ICommand _newEst;
        public ICommand newEst => _newEst ?? (_newEst = new RelayCommand(newEstimation));

        public void info_film(object item) 
        {
            int[] resEstim = new int[2];
            film f = (film)item;
            //if (selectedFilm != f)
             //   selectedFilm = f;
            if (f != null)
            {
                string name_film = f.name;
                
                infofilms = Model.GetInfoFilm(name_film);
                infoCreators = Model.GetInfoCreators(name_film);
                resEstim = Model.checkRev(login, selectedFilm.name);
                userEstim = resEstim[1];
            }
        }
        public void outpInformUser(object parameter)
        {
                

        }

        private ICommand _output;
        public ICommand output => _output ?? (_output = new RelayCommand(outpInformUser));
    }
}
