using Entity;
using Shared.DTO.DTOModels;
using Shared.Models;

namespace Business.Abstract
{
    public interface IRoomService
    {
        public string? Message { get; set; }
        Task<RoomListDTO> GetAllRooms(int page);
        Task<RoomListDTO> GetRoomsBySearch(RoomFilterModel model,int page);
        Task<bool> CreateAsync(RoomModel model);
        Task<Room?> GetByIdAsync(int id);
        Task<RoomDTO> GetRoomDetails(int id);
    }
}