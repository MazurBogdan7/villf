using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace villf
{
    class MainViewModel :baseVM
    {
        static SqlComponents Model = new SqlComponents();

        string name;
        public string login { get=>name; set { name = value; } }
        
        public class film
        {
            public string name { get; set; }
        }
        

            private ObservableCollection<film> _films;
            public ObservableCollection<film> films
            {
                get => _films;


                set
                {

                    _films = value;
                    OnPropertyChanged(nameof(films));
                }
            }
            int i = 0;
            /*private string _Search;
            public string SearchN
            {
                get => _Search;
                set
                {

                    _Search = value;
                    OnPropertyChanged(nameof(SearchN));
                }
            }*/


            public void checkFilm(string _Search)
            {
            ObservableCollection<string> filmsNams = null;
            if (_Search != null) { 
                
                filmsNams = Model.ChFilm(_Search); 
                    while (filmsNams.Count != 0)
                    {
                        films = new ObservableCollection<film> { new film { name = filmsNams[i] } };

                    }

                }

            }

           // private ICommand _chfilm;

           // public ICommand chfilm => _chfilm ?? (_chfilm = new RelayCommand(checkFilm));

            public void outpInformUser(object parameter)
            {
                

            }

            private ICommand _output;

            public ICommand output => _output ?? (_output = new RelayCommand(outpInformUser));

        
    }
}
