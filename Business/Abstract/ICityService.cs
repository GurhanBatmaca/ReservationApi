using Entity;
using Shared.DTO.DTOModels;

namespace Business.Abstract
{
    public interface ICityService
    {
        public string? Message { get; set; }
        Task<CityListDTO> GetAllAync();
    }
}