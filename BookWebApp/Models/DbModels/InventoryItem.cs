using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookWebApp.Models
{
    public partial class InventoryItem
    {
        [Key]
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public int? Rating { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty("InventoryItem")]
        public virtual Book Book { get; set; }
        [ForeignKey(nameof(InventoryId))]
        [InverseProperty(nameof(UserInventory.InventoryItem))]
        public virtual UserInventory Inventory { get; set; }
    }
}
