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
        public async Task<List<HotelDTO>> GetHomePageHotels(int page, int pageSize)
        {
            var Hotels = await _unitOfWork.Hotels.GetHomePageHotels(page,pageSize);

            var hotelDtoList = Hotels.Select(i=> new HotelDTO{
                Name = i.Name,
                Stars = i.Stars,
                TotalRoom = i.TotalRoom,
                RoomService = i.RoomService,
                AllInclusive = i.AllInclusive,
                ImageUrl = i.ImageUrl,
                CityName = i.City!.Name,
                CompanyName = i.Company!.Name,
                City = new City {
                    Name = i.City.Name
                }
            });

            return hotelDtoList.ToList();
        }

    }
}