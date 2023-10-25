using Entity;

namespace Data.Abstract
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Task<List<Hotel>> GetHomePageHotels(int page,int pageSize);
    }
}