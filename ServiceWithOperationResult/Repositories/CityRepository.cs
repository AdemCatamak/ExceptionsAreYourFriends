using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceWithOperationResult.Models;

namespace ServiceWithOperationResult.Repositories
{
    public interface ICityRepository
    {
        Task<OperationResult<City>> GetCity(int id);
    }

    public class CityRepository : ICityRepository
    {
        private readonly IEnumerable<City> _cities
            = new List<City>
              {
                  new City(1, "istanbul"),
                  new City(1, "izmir"),
                  new City(1, "ankara"),
              };

        public Task<OperationResult<City>> GetCity(int id)
        {
            var city = _cities.FirstOrDefault(c => c.Id == id);

            var result = city == null
                             ? new OperationResult<City>($"#{id} city could not found")
                             : new OperationResult<City>(city);

            return Task.FromResult(result);
        }
    }
}