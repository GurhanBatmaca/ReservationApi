using Entity;
using Shared.DTO.DTOModels;

namespace Business.Abstract
{
    public interface ICityService
    {
        Task<CityListDTO> GetAllAync();
    }
}