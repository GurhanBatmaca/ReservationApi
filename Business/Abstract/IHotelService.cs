using Entity;
using Shared.DTO.Models;

namespace Business.Abstract
{
    public interface IHotelService
    {
        Task<List<HotelDTO>> GetHomePageHotels(int page, int pageSize);
    }
}