using Entity;
using Shared.DTO.DTOModels;
using Shared.Helpers;

namespace Shared.DTO.EntityToDTO
{
    public static class CompanyToCompanyDTO
    {
        public static List<CompanyDTO> CompanyListToCompanyDTOList(List<Company> companies)
        {

           var companyDtoList = companies.Select(i=> new CompanyDTO
            {
                CompanyId = i.CompanyId,
                Name = i.Name,
                Url = i.Url
            });

            return companyDtoList.ToList();
        }
    }
}