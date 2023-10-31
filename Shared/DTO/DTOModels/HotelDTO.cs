using Entity;

namespace Shared.DTO.DTOModels
{
    public class HotelDTO
    {
        public int HotelId { get; set; }
        public string? Name { get; set; }
        public int Stars { get; set; }
        public int TotalRoom { get; set; }
        public bool RoomService { get; set; }
        public bool AllInclusive { get; set; }
        public string? ImageUrl { get; set; }
        public string? Url { get; set; }
        public CityDTO? City { get; set; }
        public CompanyDTO? Company { get; set; }
    }
}