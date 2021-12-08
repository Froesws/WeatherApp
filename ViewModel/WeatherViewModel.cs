using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public SearchCommand SearchCommand { get; set; }

        private string query;

        public string Query
        {
            get
            {
                return query;
            }
            set
            {
                query = value;
                OnPropertyChanged(nameof(Query));
            }
        }

        private CurrentConditions currentConditions;
        public CurrentConditions CurrentConditions
        {
            get
            {
                return currentConditions;
            }
            set
            {
                currentConditions = value;
                OnPropertyChanged(nameof(CurrentConditions));
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get
            {
                return selectedCity;
            }
            set
            {
                selectedCity = value;
                OnPropertyChanged(nameof(SelectedCity));
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public WeatherViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                SelectedCity = new City
                {
                    LocalizedName = "New York"
                };

                CurrentConditions = new CurrentConditions
                {
                    WeatherText = "Partly Cloudly",
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = 22
                        }
                    }
                };
            }

            SearchCommand = new SearchCommand(this);
        }

        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);
        }

    }
}
