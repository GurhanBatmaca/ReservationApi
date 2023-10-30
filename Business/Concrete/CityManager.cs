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

    }
}