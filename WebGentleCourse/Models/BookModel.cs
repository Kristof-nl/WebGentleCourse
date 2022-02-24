using System.ComponentModel.DataAnnotations;
using WebGentleCourse.Enums;

namespace WebGentleCourse.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter a book name")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a book author")]
        public string Author { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please choose a language")]
        public string Language { get; set; }
        public LanguageEnum LanguageEnum { get; set; }
        [Required(ErrorMessage = "Please enter a total pages")]
        [Display(Name ="Total Pages")]
        public int? TotalPages { get; set; }
    }
}
