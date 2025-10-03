using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web_API_Versioning.API;
using Web_API_Versioning.API.Models.Domain;
using Web_API_Versioning.API.Models.DTOs;

namespace Web_API_Versioning.API.V1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCountries()
        {
            var countriesDomainModel = CountriesData.Get();
            var response = new List<CountryDtoV1>();

            foreach (var countryDomain in countriesDomainModel)
            {
                response.Add(new CountryDtoV1
                {
                    Id = countryDomain.Id,
                    Name = countryDomain.Name
                });
            }

            return Ok(response);
        }
    }
}
