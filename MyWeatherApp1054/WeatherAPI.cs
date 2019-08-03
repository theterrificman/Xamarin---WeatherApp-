using System;
using System.Threading.Tasks;
using Refit;

namespace MyWeatherApp1054
{
    public interface IWeatherAPI
    {
        [Get("/data/2.5/weather?q={city}&units=metric&APPID=14c03dcb77cec89b14eec12ceafedb5e")]
        Task<WeatherResult> GetWeather(string city);
    }
}
