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
                
            }

        }
        private string _mail;
        public string mail
        {
            get => _mail;
            set
            {
                _mail = value;
                OnPropertyChanged(nameof(mail));
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
        public void cleaningSearch()
        {
            films.Clear();
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
        public void suggestedFilm(string login)
        {
            ObservableCollection<estimationsUser> check = new ObservableCollection<estimationsUser>();
            int i = 0;
            int j = 1;
            int k = 1;
            int nfilms;
            check = Model.GetEstim_User(login);

            if (check.Count == 0)
            {
                filmsObj = Model.suggestedFilm_rand();
            }
            else
            {
                filmsObj = Model.suggestedFilm(login);
            }
            if (filmsObj.Count == 0) filmsObj = Model.suggestedFilm_rand();
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
            Model.UpdateFilmEstim(selectedFilm.name);
            resEstim = Model.checkRev(login, selectedFilm.name);
            userEstim = resEstim[1];
        }
        private ICommand _newEst;
        public ICommand newEst => _newEst ?? (_newEst = new RelayCommand(newEstimation));

        public void info_film(object item) 
        {
            int[] resEstim = new int[2];
            film f = (film)item;
            
            if (f != null)
            {
                string name_film = f.name;
                
                infofilms = Model.GetInfoFilm(name_film);
                infoCreators = Model.GetInfoCreators(name_film);
                
                resEstim = Model.checkRev(login, selectedFilm.name);
                userEstim = resEstim[1];
            }
        }

        private ObservableCollection<estimationsUser> _infoEstimations = new ObservableCollection<estimationsUser>();
        public ObservableCollection<estimationsUser> infoEstimations
        {
            get => _infoEstimations;
            set
            {
                _infoEstimations = value;
                OnPropertyChanged(nameof(infoEstimations));
            }
        }
        public void outpInformUser(object parameter)
        {
            string log = (string)parameter;
            mail = Model.GetMailUser(log);

        }

        private ICommand _output;
        public ICommand output => _output ?? (_output = new RelayCommand(outpInformUser));

        public void EstimUser(object parameter)
        {
            string log = (string)parameter;

            infoEstimations = Model.GetEstim_User(log);
        }
        private ICommand _AllEstim;
        public ICommand AllEstim => _AllEstim ?? (_AllEstim = new RelayCommand(EstimUser));

        public void FormatSearchFilm(string year, string month, string country, string ageRating, string time, string estim, string name)
        {
            films.Clear();
            List<object> Searchfilms = new List<object>();
            Searchfilms = Model.Film_FormatSearch(
                year == "" ? null : year,
                month == "" ? null : month, 
                country == "" ? null : country, 
                ageRating == "" ? null : ageRating,
                time == "" ? null : time,
                estim == "" ? null : estim, 
                name == "" ? null : name
                );
            for(int i = 0; i < Searchfilms.Count; ++i)
            {
                string nFilm = (string)Searchfilms[i];
                byte[] poster = (byte[])Searchfilms[i = i + 1];
                films.Add(new film(nFilm, poster, 0, 0, "", "", "", "", 0, "", ""));
            }
        }
    }
}
