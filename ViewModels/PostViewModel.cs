using Application.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class PostViewModel
    {
        [Required]
        public BookCardViewModel BookCard { get; set; }
        public IEnumerable<BookCardViewModel> RecommendedItems { get; set; }
    }
}
