using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookWebApp.Models
{
    public partial class UserInventory
    {
        public UserInventory()
        {
            InventoryItem = new HashSet<InventoryItem>();
        }

        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserInventory")]
        public virtual User User { get; set; }
        [InverseProperty("Inventory")]
        public virtual ICollection<InventoryItem> InventoryItem { get; set; }
    }
}
