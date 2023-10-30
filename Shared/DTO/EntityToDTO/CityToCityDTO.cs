using Entity;
using Shared.DTO.DTOModels;
using Shared.Helpers;

namespace Shared.DTO.EntityToDTO
{
    public static class CityToCityDTO
    {
        public static List<CityDTO> HotelListToHotelDTOList(List<City> cities)
        {

           var cityDtoList = cities.Select(i=> new CityDTO
            {
                CityId = i.CityId,
                Name = i.Name,
                Url = UrlModifier.Modifie(i.Name!)
            });

            return cityDtoList.ToList();
        }
    }
}