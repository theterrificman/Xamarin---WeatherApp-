using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyWeatherApp1054
{
    public class WeatherListPageModel : FreshMvvm.FreshBasePageModel
    {
        public List<City> Cities { get; set; }

        public WeatherListPageModel()
        {
            Cities = new List<City>
            {
                new City { CityName = "Sydney", CityImage = "sydney.jpg" },
                new City { CityName = "London", CityImage = "london.jpg" },
                new City { CityName = "Brisbane", CityImage = "brisbane.jpg" }
            };

            GetCurrentLocation();
        }

        public async Task GetCurrentLocation()
        { 
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = await Geolocation.GetLocationAsync(request);

            var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);

            var result = await CoreMethods.DisplayAlert($"Your location is {placemarks.First().Locality}", "Would you like to get the weather", "Ok", "Cancel");

            if (result)
            {
                await CoreMethods.PushPageModel<WeatherViewPageModel>(new City
                {
                    CityName = placemarks.First().Locality
                });
            }
        }

        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            
        }

        City city;
        public City City
        {
            get { return city; }
            set
            {
                city = value;
                if (value != null)
                    CoreMethods.PushPageModel<WeatherViewPageModel>(value);
            }
        }
    }
}
