using Data;
using Entity;
using Shared.DTO.EntityToDTO;
using Shared.DTO.DTOModels;
using Shared.Helpers;
using Shared.Models;
using Shared.DTO.DTOToEntity;

namespace Business.Abstract
{
    public class RoomManager : IRoomService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public RoomManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string? Message { get; set; }


        public async Task<bool> CreateAsync(RoomModel model)
        {
            if(string.IsNullOrEmpty(model.Name))
            {
                Message += "Name is required.";
                return false;
            }
            if(model.Price <= 0)
            {
                Message += "Price most be positive number.";
                return false;
            }            
            if(model.Discount > 100)
            {
                Message += "Not valid number.";
                return false;
            }
            var hotel = await _unitOfWork.Hotels.GetByIdAsync(model.HotelId);
            if(hotel == null)
            {
                Message += "Not valid id.";
                return false;
            }

            var entity = RoomDTOToRoom.RoomDTOToRoomEntity(model);
            await _unitOfWork.Rooms.CreateAsync(entity);
            
            Message += "Room is created.";

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Rooms.GetByIdAsync(id);
            if(entity == null)    
            {
                Message += "Room not found.";
                return false;
            }

            await _unitOfWork.Rooms.DeleteAsync(entity);

            Message += "Room deleted.";
            return true;
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

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Rooms.GetByIdAsync(id);
        }


        public async Task<RoomDTO> GetRoomDetails(int id)
        {
            var entity = await _unitOfWork.Rooms.GetRoomDetails(id);
            return RoomToRoomDTO.RoomToRoomDTOObject(entity!);
            
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