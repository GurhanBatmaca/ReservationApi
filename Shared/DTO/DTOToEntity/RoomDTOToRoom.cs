using Entity;
using Shared.Models;

namespace Shared.DTO.DTOToEntity
{
    public static class RoomDTOToRoom
    {
        public static Room RoomDTOToRoomEntity(RoomModel model)
        {
            var room = new Room
            {
                RoomNumber = model.RoomNumber,
                Name = model.Name,
                Price = model.Price,
                Discount = model.Discount,
                SquareMeters = model.SquareMeters,
                BedsCount = model.BedsCount,
                IsEmpty = model.IsEmpty,
                EntryDate = model.EntryDate,
                ReleaseDate = model.ReleaseDate,
                GuestCapacity = model.GuestCapacity,
                InnerRoomCount = model.InnerRoomCount,
                Tv = model.Tv,
                ImageUrl = model.ImageUrl,
                HotelId = model.HotelId

            };

            return room;
        }
    }
}