using Infrastructure.Entities.Location;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsosWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IRepository<CountryEntity> _countryEntity;

        public CountryController(IRepository<CountryEntity> countryEntity)
        {
            _countryEntity = countryEntity;
        }

        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            return Ok(await _countryEntity.GetAsync());
        }
    }
}
