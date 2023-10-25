namespace Entity
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string? Name { get; set; }
        public int Stars { get; set; }
        public int TotalRoom { get; set; }
        public bool RoomService { get; set; }
        public bool AllInclusive { get; set; }
        public string? ImageUrl { get; set; }

        public int CityId { get; set; }
        public City? City { get; set; }

        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        public List<Room>? Rooms { get; set; }


    }
}