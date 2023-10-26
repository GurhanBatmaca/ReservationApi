using Data;
using Entity;
using Shared.DTO.EntityToDTO;
using Shared.DTO.Models;
using Shared.Helpers;

namespace Business.Abstract
{
    public class RoomManager : IRoomService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public RoomManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RoomListDTO> GetRoomsByCity(string city, int page)
        {
            var pageSize = 2;
            var rooms = await _unitOfWork.Rooms.GetRoomsByCity(city,page,pageSize);
            var roomsCount = await _unitOfWork.Rooms.GetRoomsCountByCity(city);

            var roomListDTO = new RoomListDTO
            {
                Rooms = RoomToRoomDTO.RoomListToRoomDTOList(rooms),
                Pages = PageCountCeiling.Ceiling(roomsCount,pageSize)
            };

            return roomListDTO; 

        }


    }
}