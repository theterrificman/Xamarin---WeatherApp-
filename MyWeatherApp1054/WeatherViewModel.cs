using System;
using System.Threading.Tasks;
using Refit;

namespace MyWeatherApp1054
{
    public class WeatherViewPageModel : FreshMvvm.FreshBasePageModel
    {
        private string cityImage;
        private string cityName;
        private string cityTemp;

        public string CityImage
        {
            get => cityImage;
            set
            {
                cityImage = value;
                RaisePropertyChanged(nameof(CityImage));
            }
        }
        public string CityName
        {
            get => cityName;
            set 
            {
                cityName = value;
                RaisePropertyChanged(nameof(CityName));
            }
        }
        public string CityTemp
        {
            get => cityTemp;
            set
            {
                cityTemp = value;
                RaisePropertyChanged(nameof(CityTemp));
            }
        }

        public WeatherViewPageModel()
        {
            
        }

        async Task GetWeather(string cityname)
        {
            var weatherapi = RestService.For<IWeatherAPI>("https://api.openweathermap.org/");
            var weatherResult = await weatherapi.GetWeather(cityname);
            CityTemp = weatherResult.main.temp.ToString();
        }

        public override void Init(object initData)
        {
            var city = initData as City;
            CityName = city.CityName;
            CityImage = city.CityImage;
            GetWeather(CityName);
        }
    }
}
