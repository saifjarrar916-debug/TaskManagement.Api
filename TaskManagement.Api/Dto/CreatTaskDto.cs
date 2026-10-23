using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Api.Dto
{
    public class CreatTaskDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        [RegularExpression("Pending|InProgress|Completed")]
        public string Status { get; set; } = "Pending";
        public string? Description { get; set; }

      
    }
}
