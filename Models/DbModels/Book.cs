using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Application.Models
{
    public partial class Book
    {
/*        public Book()
        {
            // CartItem = new HashSet<CartItem>();
            // InventoryItem = new HashSet<InventoryItem>();
        }
*/
        [Key]
        public ulong Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Author { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [StringLength(255)]
        public string? ImageURL { get; set; }
        public ulong? SoldQuantity { get; set; }
        public float? Rating { get; set; }

        [InverseProperty(nameof(Book))]
        public virtual ICollection<CartItem> CartItems { get; set; }
        [InverseProperty(nameof(Book))]
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
        [InverseProperty(nameof(Book))]
        public virtual ICollection<BookCategory> BookCategories { get; set; }
        [InverseProperty(nameof(Book))]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
