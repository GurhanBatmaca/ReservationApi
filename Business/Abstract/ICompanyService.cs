using Entity;
using Shared.DTO.DTOModels;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        Task<CompanyListDTO> GetAllAync();
    }
}