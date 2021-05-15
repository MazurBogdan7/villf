using System;
using System.Collections.Generic;
using System.Text;

namespace villf
{
    public class film : baseVM
    {
        private string _name;
        private byte[] _poster;
        /*public string name
        {
            get => _name;
            set
            {

                _name = value;
                OnPropertyChanged(nameof(name));
            }
        }
        public byte[] poster
        {
            get => _poster;
            set
            {

                _poster = value;
                OnPropertyChanged(nameof(poster));
            }
        }*/
        public string name 
        {
            get => _name;
            set
            {

                _name = value;
                OnPropertyChanged(nameof(name));
            }

        }
        public byte[] poster 
        {
            get => _poster;
            set
            {

                _poster = value;
                OnPropertyChanged(nameof(poster));
            }

        }
        public film(string Name, byte[] Poster)
        {
            name = Name;
            poster = Poster;
        }
    }
}
