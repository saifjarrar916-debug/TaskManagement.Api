using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Api.Dto
{
    public class RegisterDto
    {
        [Required]
       
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength (8)]
        public string password {  get; set; } = string.Empty;
    }
}
