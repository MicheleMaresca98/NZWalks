using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web_API_Versioning.API;
using Web_API_Versioning.API.Models.Domain;
using Web_API_Versioning.API.Models.DTOs;

namespace Web_API_Versioning.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        public IActionResult GetCountriesV1()
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

        [HttpGet]
        [MapToApiVersion("2.0")]
        public IActionResult GetCountriesV2()
        {
            var countriesDomainModel = CountriesData.Get();
            var response = new List<CountryDtoV2>();

            foreach (var countryDomain in countriesDomainModel)
            {
                response.Add(new CountryDtoV2
                {
                    Id = countryDomain.Id,
                    CountryName = countryDomain.Name
                });
            }

            return Ok(response);
        }
    }
}
