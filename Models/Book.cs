using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ReadingLifeProject.Models
{
    public class Book
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public DateTime Date { get; set; } 

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }

        public Category? Category { get; set; }

        [StringLength(500)]
        public string Review { get; set; }

        [Range(0.0,5.0)]
        public float Nota { get; set; }
    }
}
