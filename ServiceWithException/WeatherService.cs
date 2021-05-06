using System.Threading.Tasks;
using ServiceWithException.Models;
using ServiceWithException.Proxies;
using ServiceWithException.Repositories;

namespace ServiceWithException
{
    public class WeatherService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IWeatherApi _weatherApi;

        public WeatherService(ICityRepository cityRepository, IWeatherApi weatherApi)
        {
            _cityRepository = cityRepository;
            _weatherApi = weatherApi;
        }

        public async Task<Weather> GetWeatherAsync(int cityId)
        {
            var city = await _cityRepository.GetCity(cityId);
            int celsius = await _weatherApi.GetWeatherAsync(city.Name);

            var weather = new Weather(city, celsius);
            return weather;
        }
    }
}