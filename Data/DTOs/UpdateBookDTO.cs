using System.ComponentModel.DataAnnotations;

namespace ReadingLifeProject.Data.DTOs
{
    public class UpdateBookDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }
    }
}
