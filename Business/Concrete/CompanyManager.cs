using Data;
using Entity;
using Shared.DTO.EntityToDTO;
using Shared.DTO.DTOModels;
using Shared.Helpers;

namespace Business.Abstract
{
    public class CompanyManager : ICompanyService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public CompanyManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyListDTO> GetAllAync()
        {

            var companies = await _unitOfWork.Companys.GetAllAsync();

            var companyListDTO = new CompanyListDTO
            {
                Companies = CompanyToCompanyDTO.CompanyListToCompanyDTOList(companies)
            };

            return companyListDTO;
        }

    }
}