using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Api.Dto
{
    public class LoginRequestDto
    {
        [Required]
        
        public string Email { get; set; } = string.Empty;
        [Required]
    
        public string password { get; set; } = string.Empty;

    }
}
