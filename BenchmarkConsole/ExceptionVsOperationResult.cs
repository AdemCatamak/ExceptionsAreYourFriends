using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using ServiceWithException.Exceptions;
using ServiceWithException.Models;

namespace BenchmarkConsole
{
    [SimpleJob(launchCount: 3, warmupCount: 10, targetCount: 30)]
    public class ExceptionVsOperationResult
    {
        [Params(0, 1)] public int CityId;

        [Benchmark]
        public async Task WeatherWithException()
        {
            var weatherWithException = new ServiceWithException.WeatherService(new ServiceWithException.Repositories.CityRepository(), new ServiceWithException.Proxies.WeatherApi(true));

            try
            {
                var weather = await weatherWithException.GetWeatherAsync(CityId);
                // Console.WriteLine($"The air temperature in {weather.City.Name} is {weather.Celsius} degrees Celsius.");
            }
            catch (NotFoundException<City> ex)
            {
                // Console.WriteLine(ex.Message);
            }
            catch (IntegrationException ex)
            {
                // Console.WriteLine(ex.Message);
            }
        }

        [Benchmark]
        public async Task WeatherWithOperationResult()
        {
            var weatherWithOperationResult = new ServiceWithOperationResult.WeatherService(new ServiceWithOperationResult.Repositories.CityRepository(), new ServiceWithOperationResult.Proxies.WeatherApi(true));

            var operationResult = await weatherWithOperationResult.GetWeatherAsync(CityId);
            if (operationResult.Succeed)
            {
                var weather = operationResult.Result;
                // Console.WriteLine($"The air temperature in {weather.City.Name} is {weather.Celsius} degrees Celsius.");
            }
            else
            {
                // Console.WriteLine(operationResult.ErrorCode);
            }
        }
    }
}