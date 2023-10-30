using Entity;
using Shared.DTO.DTOModels;
using Shared.Models;

namespace Business.Abstract
{
    public interface IRoomService
    {
        Task<RoomListDTO> GetAllRooms(int page);
        Task<RoomListDTO> GetRoomsBySearch(RoomFilterModel model,int page);
    }
}