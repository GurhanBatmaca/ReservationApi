namespace Shared.Models
{
    public class RoomFilterModel
    {
        public string? City { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? EntryDate { get; set; } 
        public string? ReleaseDate { get; set; } 
    }
}