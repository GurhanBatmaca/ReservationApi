using Entity;
using Shared.DTO.Models;

namespace Shared.DTO.EntityToDTO
{
    public static class HotelToHotelDTO
    {
        public static List<HotelDTO> HotelListToHotelDTOList(List<Hotel> hotels)
        {

           var hotelDtoList = hotels.Select(i=> new HotelDTO
            {
                HotelId = i.HotelId,
                Name = i.Name,
                Stars = i.Stars,
                TotalRoom = i.TotalRoom,
                RoomService = i.RoomService,
                AllInclusive = i.AllInclusive,
                ImageUrl = i.ImageUrl,
                City = new CityDTO {
                    CityId = i.City!.CityId,
                    Name = i.City!.Name
                },
                Company = new CompanyDTO {
                    CompanyId = i.Company!.CompanyId,
                    Name = i.Company.Name
                }
            });

            return hotelDtoList.ToList();
        }
    }
}