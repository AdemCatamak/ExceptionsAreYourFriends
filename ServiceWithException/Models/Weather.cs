namespace ServiceWithException.Models
{
    public class Weather
    {
        public City City { get; private set; }
        public int Celsius { get; private set; }

        public Weather(City city, int celsius)
        {
            City = city;
            Celsius = celsius;
        }
    }
}