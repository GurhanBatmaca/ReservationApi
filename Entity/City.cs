namespace Entity
{
    public class City
    {
        public int CityId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public List<Hotel>? Hotels { get; set; }
    }
}