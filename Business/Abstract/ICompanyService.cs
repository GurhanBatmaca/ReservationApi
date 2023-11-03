using Entity;
using Shared.DTO.DTOModels;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        public string? Message { get; set; }
        Task<CompanyListDTO> GetAllAync();
    }
}