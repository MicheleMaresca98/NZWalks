using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.Dto
{
    public class LoginResponseDto
    {
        [Required]
        public string JwtToken { get; set; }
    }
}