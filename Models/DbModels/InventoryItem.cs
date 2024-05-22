using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Application.Models
{
    public partial class InventoryItem
    {
        [Key]
        public ulong Id { get; set; }
        [Required]
        public ulong InventoryId { get; set; }
        [Required]
        public ulong BookId { get; set; }
        [Required]
        public uint Quantity { get; set; }
        public byte? Rating { get; set; }

        [ForeignKey(nameof(BookId))]
        // [InverseProperty(nameof(InventoryItem))]
        public virtual Book Book { get; set; }
        [ForeignKey(nameof(InventoryId))]
        // [InverseProperty(nameof(UserInventory.InventoryItem))]
        public virtual UserInventory UserInventory { get; set; }
    }
}
