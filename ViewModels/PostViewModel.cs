using Application.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class PostViewModel
    {
        [Required]
        public BookData BookData { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public IEnumerable<BookData> RecommendedItems { get; set; }
    }
}
