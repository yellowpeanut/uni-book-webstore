using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Application.Models
{
    public partial class BookCategory
    {
        [Key]
        public ulong Id { get; set; }
        [Required]
        public ulong BookId { get; set; }
        [Required]
        public uint CategoryId { get; set; }
        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}
