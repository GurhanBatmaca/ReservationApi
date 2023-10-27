using Entity;

namespace Data.Abstract
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<List<Room>> GetRoomsByCity(string city,int page,int pageSize);
        Task<int> GetRoomsCountByCity(string city);
        Task<List<Room>> GetRoomsByFilter(string? city,int minPrice,int maxPrice,int page,int pageSize);
        Task<int> GetRoomsCountByFilter(string? city,int minPrice,int maxPrice);
    }
}