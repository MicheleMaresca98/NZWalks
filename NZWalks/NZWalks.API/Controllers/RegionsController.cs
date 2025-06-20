using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionsController : ControllerBase
{
    private readonly IRegionRepository regionRepository;

    public RegionsController(IRegionRepository regionRepository)
    {
        this.regionRepository = regionRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var regionsDomain = await regionRepository.GetAllAsync();
        var regionsDto = new List<RegionDto>();
        foreach (var regionDomain in regionsDomain)
        {
            regionsDto.Add(new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl,
            });
        }
        return Ok(regionsDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
    {
        var regionDomainModel = new Region
        {
            Code = addRegionRequestDto.Code,
            Name = addRegionRequestDto.Name,
            RegionImageUrl = addRegionRequestDto.RegionImageUrl
        };

        regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

        var regionDto = new RegionDto
        {
            Id = regionDomainModel.Id,
            Name = regionDomainModel.Name,
            Code = regionDomainModel.Code,
            RegionImageUrl = regionDomainModel.RegionImageUrl,
        };

        return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var region = await regionRepository.GetByIdAsync(id);
        if (region == null)
        {
            return NotFound();
        }
        var regionDto = new RegionDto
        {
            Id = region.Id,
            Name = region.Name,
            Code = region.Code,
            RegionImageUrl = region.RegionImageUrl,
        };
        return Ok(regionDto);
    }

    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
    {
        var regionDomainModel = new Region
        {
            Code = updateRegionRequestDto.Code,
            Name = updateRegionRequestDto.Name,
            RegionImageUrl = updateRegionRequestDto.RegionImageUrl
        };
        
        regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
        if (regionDomainModel == null)
        {
            return NotFound();
        }

        var regionDto = new RegionDto
        {
            Id = regionDomainModel.Id,
            Name = regionDomainModel.Name,
            Code = regionDomainModel.Code,
            RegionImageUrl = regionDomainModel.RegionImageUrl,
        };

        return Ok(regionDto);
    }

    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var regionDomainModel = await regionRepository.DeleteAsync(id);
        if (regionDomainModel == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
