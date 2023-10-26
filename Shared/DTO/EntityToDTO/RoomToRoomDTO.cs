using Entity;
using Shared.DTO.Models;

namespace Shared.DTO.EntityToDTO
{
    public static class RoomToRoomDTO
    {
        public static List<RoomDTO> RoomListToRoomDTOList(List<Room> rooms)
        {

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
            
            return roomDTOList.ToList();
        }
    }
}