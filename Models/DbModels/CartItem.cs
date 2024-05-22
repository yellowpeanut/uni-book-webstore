using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Application.Models
{
    public partial class CartItem
    {
        [Key]
        public ulong Id { get; set; }
        [Required]
        public ulong CartId { get; set; }
        [Required]
        public ulong BookId { get; set; }
        [Required]
        public uint Quantity { get; set; }

        // [ForeignKey(nameof(BookId))]
        // [InverseProperty("CartItem")]
        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }
        // [ForeignKey(nameof(CartId))]
        // [InverseProperty(nameof(UserCart.CartItem))]
        [ForeignKey(nameof(CartId))]
        public virtual UserCart UserCart { get; set; }
    }
}
