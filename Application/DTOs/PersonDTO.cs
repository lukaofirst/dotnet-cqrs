using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string? Name { get; set; }
        [Required]
        [Range(0, 100)]
        public int Age { get; set; }
    }
}
