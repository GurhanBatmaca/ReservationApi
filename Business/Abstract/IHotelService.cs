using Entity;

namespace Business.Abstract
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetHomePageHotels(int page, int pageSize);
    }
}