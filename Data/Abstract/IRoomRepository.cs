using Entity;
using Shared.Models;

namespace Data.Abstract
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<List<Room>> GetAllRooms(int page,int pageSize);
        Task<int> GetAllRoomsCount();
        Task<List<Room>> GetRoomsBySearch(RoomFilterModel model,int page,int pageSize);
        Task<int> GetRoomsCountBySearch(RoomFilterModel model);
    }
}