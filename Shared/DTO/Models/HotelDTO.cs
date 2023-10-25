using Entity;

namespace Shared.DTO.Models
{
    public class HotelDTO
    {
        public string? Name { get; set; }
        public int Stars { get; set; }
        public int TotalRoom { get; set; }
        public bool RoomService { get; set; }
        public bool AllInclusive { get; set; }
        public string? ImageUrl { get; set; }
        public string? CityName { get; set; }
        public string? CompanyName { get; set; }

        public City? City { get; set; }
    }
}