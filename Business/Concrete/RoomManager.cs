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

        public async Task<RoomListDTO> GetRoomsByFilter(string? city, int minPrice, int maxPrice, int page)
        {
            var pageSize = 2;
            var rooms = await _unitOfWork.Rooms.GetRoomsByFilter(city,minPrice,maxPrice,page,pageSize);
            var roomsCount = await _unitOfWork.Rooms.GetRoomsCountByFilter(city,minPrice,maxPrice);

            var roomListDTO = new RoomListDTO
            {
                Rooms = RoomToRoomDTO.RoomListToRoomDTOList(rooms),
                Pages = PageCountCeiling.Ceiling(roomsCount,pageSize)
            };

            return roomListDTO; 
        }

        public async Task<RoomListDTO> GetRoomsByModel(RoomFilterModel model, int page)
        {
            var pageSize = 2;
            var rooms = await _unitOfWork.Rooms.GetRoomsByModel(model,page,pageSize);

            var roomListDTO = new RoomListDTO
            {
                Rooms = RoomToRoomDTO.RoomListToRoomDTOList(rooms)
            };

            return roomListDTO; 
        }
    }
}