using Data;
using Entity;
using Shared.DTO.Models;

namespace Business.Abstract
{
    public class HotelManager : IHotelService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public HotelManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<HotelDTO>> GetHomePageHotels(int page)
        {
            var pageSize = 3;
            var hotels = await _unitOfWork.Hotels.GetHomePageHotels(page,pageSize);

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