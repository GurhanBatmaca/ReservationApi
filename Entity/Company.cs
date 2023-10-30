namespace Entity
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }

        public List<Hotel>? Hotels { get; set; }
    }
}