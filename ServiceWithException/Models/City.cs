namespace ServiceWithException.Models
{
    public class City
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public City(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}