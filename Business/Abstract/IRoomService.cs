using Entity;
using Shared.DTO.DTOModels;

namespace Business.Abstract
{
    public interface IRoomService
    {
        Task<RoomListDTO> GetRoomsByCity(string city, int page);
        Task<RoomListDTO> GetRoomsByFilter(string? city,int minPrice,int maxPrice,int page);
    }
}