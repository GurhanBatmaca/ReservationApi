using Entity;
using Shared.DTO.Models;

namespace Business.Abstract
{
    public interface IHotelService
    {
        Task<HotelListDTO> GetHomePageHotels(int page);
    }
}