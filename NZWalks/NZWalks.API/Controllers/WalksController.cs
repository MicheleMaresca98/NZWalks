using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalksController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IWalkRepository walkRepository;

    public WalksController(IMapper mapper, IWalkRepository walkRepository)
    {
        this.mapper = mapper;
        this.walkRepository = walkRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? filterOn,
        [FromQuery] string? filterQuery,
        [FromQuery] string? sortBy,
        [FromQuery] bool? isAscending,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 1000
    )
    {
        var walksDomain = await walkRepository.GetAllAsync(
            filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);
        return Ok(mapper.Map<List<WalkDto>>(walksDomain));
    }

    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
    {
        var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);
        walkDomainModel = await walkRepository.CreateAsync(walkDomainModel);
        return CreatedAtAction(nameof(GetById), new { id = walkDomainModel.Id }, mapper.Map<WalkDto>(walkDomainModel));
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var walk = await walkRepository.GetByIdAsync(id);
        if (walk == null)
        {
            return NotFound();
        }
        return Ok(mapper.Map<WalkDto>(walk));
    }

    [HttpPut]
    [Route("{id:Guid}")]
    [ValidateModel]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
    {
        var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);
        walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);
        if (walkDomainModel == null)
        {
            return NotFound();
        }
        return Ok(mapper.Map<WalkDto>(walkDomainModel));
    }

    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var walkDomainModel = await walkRepository.DeleteAsync(id);
        if (walkDomainModel == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
