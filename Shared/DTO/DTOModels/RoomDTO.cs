using Entity;

namespace Shared.DTO.DTOModels
{
    public class RoomDTO
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int SquareMeters { get; set; }
        public int BedsCount { get; set; }
        public bool IsEmpty { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GuestCapacity { get; set; }
        public int InnerRoomCount { get; set; }
        public bool Tv { get; set; }
        public string? ImageUrl { get; set; }
        public HotelDTO? Hotel { get; set; }
    }
}