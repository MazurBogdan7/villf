using System;
using System.Collections.Generic;
using System.Text;

namespace villf
{
    
    public class film : baseVM
    {
        private string _name;
        private byte[] _poster;
        private int _year;
        private float _estimation;
        private string _country;
        private string _stile;
        private string _date;
        private string _time;
        private int _budget;
        private string _rating;
        private string _company;
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
        public int year
        {
            get => _year;
            set
            {
                _year = value;
                OnPropertyChanged(nameof(year));
            }

        }
        public float estimation
        {
            get => _estimation;
            set
            {
                _estimation = value;
                OnPropertyChanged(nameof(estimation));
            }

        }

        public string country
        {
            get => _country;
            set
            {
                _country = value;
                OnPropertyChanged(nameof(country));
            }
        }

        public string stile
        {
            get => _stile;
            set
            {
                _stile = value;
                OnPropertyChanged(nameof(stile));
            }
        }
        public string date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(date));
            }
        }
        public string time
        {
            get => _time;
            set
            {

                _time = value;
                OnPropertyChanged(nameof(time));
            }

        }
        public int budget
        {
            get => _budget;
            set
            {

                _budget = value;
                OnPropertyChanged(nameof(budget));
            }

        }
        public string rating
        {
            get => _rating;
            set
            {

                _rating = value;
                OnPropertyChanged(nameof(rating));
            }

        }
        public string company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged(nameof(company));
            }
        }
        public film(string Name, byte[] Poster,int Year,float Estimation,string Country,string Stile,string Date,string Time,int Budget,string Rating,string Company)
        {
            name = Name;
            poster = Poster;
            year = Year;
            estimation = Estimation;
            country = Country;
            stile = Stile;
            date = Date;
            time = Time;
            budget = Budget;
            rating = Rating;
            company = Company;
        }
    }
    public class creator : baseVM
    {
        private string _nameFilm;
        private string _profession;
        private string _name;
        private string _surname;
        private string _lastname;

        public string nameFilm
        {
            get => _nameFilm;
            set
            {

                _nameFilm = value;
                OnPropertyChanged(nameof(nameFilm));
            }

        }
        public string profession
        {
            get => _profession;
            set
            {

                _profession = value;
                OnPropertyChanged(nameof(profession));
            }

        }
        public string name
        {
            get => _name;
            set
            {

                _name = value;
                OnPropertyChanged(nameof(name));
            }

        }

        public string surname
        {
            get => _surname;
            set
            {

                _surname = value;
                OnPropertyChanged(nameof(surname));
            }

        }
        public string lastname
        {
            get => _lastname;
            set
            {

                _lastname = value;
                OnPropertyChanged(nameof(lastname));
            }

        }
        public creator(string NameFilm,string Profession,string Name,string Surname,string Lastname)
        {
            nameFilm = NameFilm;
            profession = Profession;
            name = Name;
            surname = Surname;
            lastname = Lastname;
        }

    }
}
