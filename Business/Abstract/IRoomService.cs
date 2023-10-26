using Entity;
using Shared.DTO.Models;

namespace Business.Abstract
{
    public interface IRoomService
    {
        Task<RoomListDTO> GetRoomsByCity(string city, int page);
    }
}