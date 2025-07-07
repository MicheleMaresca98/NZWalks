using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> GetAll()
    {
        var walksDomain = await walkRepository.GetAllAsync();
        return Ok(mapper.Map<List<WalkDto>>(walksDomain));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
    {
        if (ModelState.IsValid)
        {
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);
            walkDomainModel = await walkRepository.CreateAsync(walkDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = walkDomainModel.Id }, mapper.Map<WalkDto>(walkDomainModel));
        }
        else
        {
            return BadRequest(ModelState);
        }
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
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
    {
        if (ModelState.IsValid)
        {
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);
            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
        else
        {
            return BadRequest(ModelState);
        }
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
