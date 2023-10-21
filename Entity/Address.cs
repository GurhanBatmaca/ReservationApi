namespace Entity
{
    public class Address
    {
        public int AddressId { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? FullAddress { get; set; }

        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
    }
}