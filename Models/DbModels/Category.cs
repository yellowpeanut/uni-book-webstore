using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Application.Models
{
    public partial class Category
    {
        [Key]
        public uint Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Value { get; set; }
        [InverseProperty(nameof(Category))]
        public virtual ICollection<BookCategory> BookCategories { get; set;}
    }
}
