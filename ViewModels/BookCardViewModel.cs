using Application.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class BookCardViewModel
    {
        [Required]
        public BookData BookData { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public uint Price { get; set; }
        public ushort ReleaseYear { get; set; }
        [Required]
        public ulong PostId { get; set; }
    }
}
