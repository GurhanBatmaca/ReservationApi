using Entity;
using Shared.DTO.DTOModels;

namespace Business.Abstract
{
    public interface IHotelService
    {
        Task<HotelListDTO> GetHomePageHotels(int page);
    }
}