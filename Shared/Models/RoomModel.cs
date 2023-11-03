using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class RoomModel
    {

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public double Price { get; set; }
        public double Discount { get; set; }

        [Required]
        public int SquareMeters { get; set; }

        [Required]
        public int BedsCount { get; set; }
        public bool IsEmpty { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int GuestCapacity { get; set; }

        [Required]
        public int InnerRoomCount { get; set; }
        public bool Tv { get; set; }

        [Required]
        public string? ImageUrl { get; set; }

        [Required]
        public int HotelId { get; set; }

        
    }
}