using System.Threading.Tasks;
using ServiceWithOperationResult.Models;
using ServiceWithOperationResult.Proxies;
using ServiceWithOperationResult.Repositories;

namespace ServiceWithOperationResult
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

        public async Task<OperationResult<Weather>> GetWeatherAsync(int cityId)
        {
            OperationResult<Weather> result;
            var getCityOperationResult = await _cityRepository.GetCity(cityId);
            if (!getCityOperationResult.Succeed)
            {
                result = new OperationResult<Weather>(getCityOperationResult.ErrorCode);
                return result;
            }

            var city = getCityOperationResult.Result;
            var getWeatherOperationResult = await _weatherApi.GetWeatherAsync(city.Name);
            if (!getWeatherOperationResult.Succeed)
            {
                result = new OperationResult<Weather>(getWeatherOperationResult.ErrorCode);
                return result;
            }

            int celsius = getWeatherOperationResult.Result;

            var weather = new Weather(city, celsius);
            result = new OperationResult<Weather>(weather);

            return result;
        }
    }
}