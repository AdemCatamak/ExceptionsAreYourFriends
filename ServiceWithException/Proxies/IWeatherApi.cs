using System;
using System.Threading.Tasks;
using ServiceWithException.Exceptions;

namespace ServiceWithException.Proxies
{
    public interface IWeatherApi
    {
        Task<int> GetWeatherAsync(string cityName);
    }

    public class WeatherApi : IWeatherApi
    {
        private readonly bool _isServerUp;
        private readonly Random _random;

        public WeatherApi(bool isServerUp)
        {
            _isServerUp = isServerUp;
            _random = new Random();
        }

        public Task<int> GetWeatherAsync(string cityName)
        {
            if (!_isServerUp)
            {
                throw new IntegrationException("WeatherApi");
            }

            int celsius = _random.Next(-20, 30);
            return Task.FromResult(celsius);
        }
    }
}