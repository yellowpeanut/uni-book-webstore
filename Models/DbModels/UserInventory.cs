using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Application.Models
{
    public partial class UserInventory
    {
/*        public UserInventory()
        {
            InventoryItems = new HashSet<InventoryItem>();
        }*/

        [Key]
        public ulong Id { get; set; }
        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        // [InverseProperty("UserInventory")]
        public virtual User User { get; set; }
        // [InverseProperty("Inventory")]
        [InverseProperty(nameof(UserInventory))]
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
