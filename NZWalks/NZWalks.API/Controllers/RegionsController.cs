using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionsController : ControllerBase
{
    private readonly IRegionRepository regionRepository;
    private readonly IMapper mapper;
    private readonly ILogger<RegionsController> logger;

    public RegionsController(
        IRegionRepository regionRepository,
        IMapper mapper,
        ILogger<RegionsController> logger
    )
    {
        this.regionRepository = regionRepository;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    [Authorize(Roles = "Reader")]
    public async Task<IActionResult> GetAll()
    {
        logger.LogInformation("GetAllRegions Action Method was invoked");
        var regionsDomain = await regionRepository.GetAllAsync();
        logger.LogInformation($"Finished GetAllRegions request with data: {JsonSerializer.Serialize(regionsDomain)}");
        return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
    }

    [HttpPost]
    [ValidateModel]
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
    {
        var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
        regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
        return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, mapper.Map<RegionDto>(regionDomainModel));
    }

    [HttpGet]
    [Route("{id:Guid}")]
    [Authorize(Roles = "Reader")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var region = await regionRepository.GetByIdAsync(id);
        if (region == null)
        {
            return NotFound();
        }
        return Ok(mapper.Map<RegionDto>(region));
    }

    [HttpPut]
    [Route("{id:Guid}")]
    [ValidateModel]
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
    {
        var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
        regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
        if (regionDomainModel == null)
        {
            return NotFound();
        }
        return Ok(mapper.Map<RegionDto>(regionDomainModel));
    }

    [HttpDelete]
    [Route("{id:Guid}")]
    [Authorize(Roles = "Writer")]
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
