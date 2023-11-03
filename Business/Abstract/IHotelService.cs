using Entity;
using Shared.DTO.DTOModels;

namespace Business.Abstract
{
    public interface IHotelService
    {
        public string? Message { get; set; }
        Task<HotelListDTO> GetHomePageHotels(int page);
        Task<HotelListDTO> GetAllHotels(int page);
    }
}