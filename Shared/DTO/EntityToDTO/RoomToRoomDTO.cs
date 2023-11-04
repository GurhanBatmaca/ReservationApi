using Entity;
using Shared.DTO.DTOModels;

namespace Shared.DTO.EntityToDTO
{
    public static class RoomToRoomDTO
    {

        public static RoomDTO RoomToRoomDTOObject(Room entity)
        {
            var room = new RoomDTO()
            {
                RoomId = entity.RoomId,
                RoomNumber = entity.RoomNumber,
                Name = entity.Name,
                Price = entity.Price,
                Discount = entity.Discount,
                SquareMeters = entity.SquareMeters,
                BedsCount = entity.BedsCount,
                IsEmpty = entity.IsEmpty,
                EntryDate = entity.EntryDate,
                ReleaseDate = entity.ReleaseDate,
                GuestCapacity = entity.GuestCapacity,
                InnerRoomCount = entity.InnerRoomCount,
                Tv =entity.Tv,
                ImageUrl = entity.ImageUrl,
                Hotel = new HotelDTO {
                    HotelId = entity.Hotel!.HotelId,
                    Name = entity.Hotel.Name,
                    Stars = entity.Hotel.Stars,
                    TotalRoom = entity.Hotel.TotalRoom,
                    RoomService = entity.Hotel.RoomService,
                    AllInclusive = entity.Hotel.AllInclusive,
                    ImageUrl = entity.Hotel.ImageUrl,
                    Url = entity.Hotel.Url,
                    City = new CityDTO {
                        CityId = entity.Hotel.City!.CityId,
                        Name = entity.Hotel.City.Name,
                        Url = entity.Hotel.City.Url
                    }
                }
            };
                   
            return room;
        }
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
                    Url = i.Hotel.Url,
                    City = new CityDTO {
                        CityId = i.Hotel.City!.CityId,
                        Name = i.Hotel.City.Name,
                        Url = i.Hotel.City.Url
                    }
                }
            });
            
            return roomDTOList.ToList();
        }
    }
}