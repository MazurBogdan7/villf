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

        public class film
        {
            public string name { get; set; }
            public film(string Name)
            {
                name = Name;
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
           
      
            public List<string> filmsNams = new List<string>();

        public void checkFilm(string _Search)
            {
                

            if (_Search != null) { 
                
                filmsNams = Model.ChFilm(_Search);
                foreach (var entry in filmsNams) //понял спасяу не за что
                {
                    

                    films.Add(new film(entry));
                }
            }

            }


            public void outpInformUser(object parameter)
            {
                

            }

            private ICommand _output;

            public ICommand output => _output ?? (_output = new RelayCommand(outpInformUser));

        
    }
}
