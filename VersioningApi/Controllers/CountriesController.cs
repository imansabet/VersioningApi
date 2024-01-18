using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VersioningApi.Models.DTOs;

namespace VersioningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() 
        {
            var countriesDomainModel = CountriesData.Get();
            // map domain to dto
            var response = new List<CountryDTO>();
            foreach (var countryDomain in countriesDomainModel) 
            {
                response.Add(new CountryDTO
                {
                    Id = countryDomain.Id,
                    Name = countryDomain.Name,
                });
            }
            return Ok(response);

        }
    }
}
