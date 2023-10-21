namespace Entity
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string? Name { get; set; }
        public int Stars { get; set; }
        public string? BranchId { get; set; }

        public List<Address>? Addresses { get; set; }
    }
}