using System;
using System.Threading.Tasks;

namespace ServiceWithOperationResult.Proxies
{
    public interface IWeatherApi
    {
        Task<OperationResult<int>> GetWeatherAsync(string cityName);
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

        public Task<OperationResult<int>> GetWeatherAsync(string cityName)
        {
            OperationResult<int> result;
            if (!_isServerUp)
            {
                result = new OperationResult<int>($"WeatherApi connection error");
                return Task.FromResult(result);
            }

            int celsius = _random.Next(-20, 30);
            result = new OperationResult<int>(celsius);
            return Task.FromResult(result);
        }
    }
}