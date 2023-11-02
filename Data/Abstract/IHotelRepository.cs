using Entity;

namespace Data.Abstract
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Task<List<Hotel>> GetHomePageHotels(int page,int pageSize);
        Task<int> GetHomePageHotelsCount();
        Task<List<Hotel>> GetAllHotels(int page,int pageSize);
        Task<int> GetAllHotelsCount();
    }
}