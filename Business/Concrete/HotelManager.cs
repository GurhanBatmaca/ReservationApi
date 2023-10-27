using Data;
using Entity;
using Shared.DTO.EntityToDTO;
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

            var hotelListDTO = new HotelListDTO 
            {
                Hotels = HotelToHotelDTO.HotelListToHotelDTOList(hotels),
                Pages = PageCountCeiling.Ceiling(hotelsCount,pageSize)
            };

            return hotelListDTO;
        }

    }
}