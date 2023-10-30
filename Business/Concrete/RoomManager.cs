using Data;
using Entity;
using Shared.DTO.EntityToDTO;
using Shared.DTO.DTOModels;
using Shared.Helpers;
using Shared.Models;

namespace Business.Abstract
{
    public class RoomManager : IRoomService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public RoomManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RoomListDTO> GetAllRooms(int page)
        {
            var pageSize = 2;
            var rooms = await _unitOfWork.Rooms.GetAllRooms(page,pageSize);
            var roomsCount = await _unitOfWork.Rooms.GetAllRoomsCount();

            var roomListDTO = new RoomListDTO
            {
                Rooms = RoomToRoomDTO.RoomListToRoomDTOList(rooms),
                Pages = PageCountCeiling.Ceiling(roomsCount,pageSize)
            };

            return roomListDTO; 
        }

        public async Task<RoomListDTO> GetRoomsBySearch(RoomFilterModel model, int page)
        {
            var pageSize = 4;
            var rooms = await _unitOfWork.Rooms.GetRoomsBySearch(model,page,pageSize);
            var roomsCount = await _unitOfWork.Rooms.GetRoomsCountBySearch(model);

            var roomListDTO = new RoomListDTO
            {
                Rooms = RoomToRoomDTO.RoomListToRoomDTOList(rooms),
                Pages = PageCountCeiling.Ceiling(roomsCount,pageSize)
            };

            return roomListDTO; 
        }
    }
}