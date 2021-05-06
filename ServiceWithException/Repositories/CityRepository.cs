using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceWithException.Exceptions;
using ServiceWithException.Models;

namespace ServiceWithException.Repositories
{
    public interface ICityRepository
    {
        Task<City> GetCity(int id);
    }

    public class CityRepository : ICityRepository
    {
        private readonly IEnumerable<City> _cities
            = new List<City>
              {
                  new City(1, "istanbul")
              };

        public Task<City> GetCity(int id)
        {
            var city = _cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
                throw new NotFoundException<City>();

            return Task.FromResult(city);
        }
    }
}