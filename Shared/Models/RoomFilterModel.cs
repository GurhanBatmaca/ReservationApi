using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class RoomFilterModel
    {
        public string? City { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }

        [Display(Name ="EntryDate YYYY-MM-DD")]
        public string? EntryDate { get; set; } 

        [Display(Name ="ReleaseDate YYYY-MM-DD")]
        public string? ReleaseDate { get; set; } 
    }
}