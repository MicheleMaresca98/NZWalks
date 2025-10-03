using Microsoft.AspNetCore.Mvc;

namespace Web_API_Versioning.API;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetCountries()
    {
        var countriesDomainModel = CountriesData.Get();
        var response = new List<CountryDto>();
        foreach (var countryDomain in countriesDomainModel)
        {
            response.Add(new CountryDto
            {
                Id = countryDomain.Id,
                Name = countryDomain.Name
            });
        }

        return Ok(response);
    }
}
