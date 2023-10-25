using Entity;

namespace Data.Abstract
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<List<Room>> GetRoomsByCity(string city,int page,int pageSize);
    }
}