using Data;
using Entity;
using Shared.DTO.EntityToDTO;
using Shared.DTO.DTOModels;
using Shared.Helpers;

namespace Business.Abstract
{
    public class CityManager : ICityService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public CityManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string? Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public async Task<CityListDTO> GetAllAync()
        {

            var cities = await _unitOfWork.Citys.GetAllAsync();

            var cityListDTO = new CityListDTO 
            {
                Cities = CityToCityDTO.CityListToCityDTOList(cities)
            };

            return cityListDTO;
        }
    }
}