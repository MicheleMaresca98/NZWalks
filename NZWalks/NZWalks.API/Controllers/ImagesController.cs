using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagesController : ControllerBase
{
    private readonly IImageRepository imageRepository;

    public ImagesController(IImageRepository imageRepository)
    {
        this.imageRepository = imageRepository;
    }
    
    [HttpPost]
    [Route("Upload")]
    public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
    {
        ValidateFileUpload(request);

        if (ModelState.IsValid)
        {
            var imageDomainModel = new Image
            {
                FileName = request.FileName,
                FileDescription = request.FileDescription,
                FileExtension = Path.GetExtension(request.File.FileName),
                FileSizeInBytes = request.File.Length,
                File = request.File
            };
            imageDomainModel = await imageRepository.Upload(imageDomainModel);
            return Ok(imageDomainModel);
        }

        return BadRequest(ModelState);
    }

    private void ValidateFileUpload(ImageUploadRequestDto request)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png"};
        var maxFileSizeInBytes = 10 * 1024 * 1024; // 10 MB

        var fileExtension = Path.GetExtension(request.File.FileName).ToLower();
        if (!allowedExtensions.Contains(fileExtension))
        {
            ModelState.AddModelError("file", "Unsupported file extension");
        }

        if (request.File.Length > maxFileSizeInBytes)
        {
            ModelState.AddModelError("file", "File size exceeds the maximum limit of 10 MB.");
        }
    }
}
