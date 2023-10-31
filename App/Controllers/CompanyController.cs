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
            var companies = await _companyService.GetAllAync();

            if(companies == null)
            {
                return BadRequest();
            }

            return Ok(companies);
        }
    }
}