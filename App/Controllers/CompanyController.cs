using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CompanyController: ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet]
        [Route("companies")]
        public async Task<IActionResult> Companies()
        {
            var companyListDTO = await _companyService.GetAllAync();

            if(companyListDTO == null)
            {
                return BadRequest();
            }
            if(companyListDTO.Companies!.Count == 0)
            {
                return NoContent();
            }

            return Ok(companyListDTO);
        }
    }
}