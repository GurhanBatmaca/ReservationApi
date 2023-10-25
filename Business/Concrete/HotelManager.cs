using Data;
using Entity;
using Shared.DTO.Models;
using Shared.Helpers;

namespace Business.Abstract
{
    public class HotelManager : IHotelService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public HotelManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<HotelListDTO> GetHomePageHotels(int page)
        {
            var pageSize = 2;

            var hotels = await _unitOfWork.Hotels.GetHomePageHotels(page,pageSize);
            var hotelsCount = await _unitOfWork.Hotels.GetHomePageHotelsCount();

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

            var hotelListDTO = new HotelListDTO 
            {
                Hotels = hotelDtoList.ToList(),
                Pages = PageCountCeiling.Ceiling(hotelsCount,pageSize)
            };

            return hotelListDTO;
        }

    }
}