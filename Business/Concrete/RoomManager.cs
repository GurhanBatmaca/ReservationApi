using Data;
using Entity;
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

            var roomDTOList = rooms.Select(i => new RoomDTO {
                RoomId = i.RoomId,
                RoomNumber = i.RoomNumber,
                Name = i.Name,
                Price = i.Price,
                Discount = i.Discount,
                SquareMeters = i.SquareMeters,
                BedsCount = i.BedsCount,
                IsEmpty = i.IsEmpty,
                EntryDate = i.EntryDate,
                ReleaseDate = i.ReleaseDate,
                GuestCapacity = i.GuestCapacity,
                InnerRoomCount = i.InnerRoomCount,
                Tv =i.Tv,
                ImageUrl = i.ImageUrl,
                Hotel = new HotelDTO {
                    HotelId = i.Hotel!.HotelId,
                    Name = i.Hotel.Name,
                    Stars = i.Hotel.Stars,
                    TotalRoom = i.Hotel.TotalRoom,
                    RoomService = i.Hotel.RoomService,
                    AllInclusive = i.Hotel.AllInclusive,
                    ImageUrl = i.Hotel.ImageUrl,
                    City = new CityDTO {
                        CityId = i.Hotel.City!.CityId,
                        Name = i.Hotel.City.Name
                    }
                }
            });

            var roomListDTO = new RoomListDTO
            {
                Rooms = roomDTOList.ToList(),
                Pages = PageCountCeiling.Ceiling(roomsCount,pageSize)
            };

            return roomListDTO; 

        }


    }
}