using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookWebApp.Models
{
    public partial class Book
    {
        public Book()
        {
            CartItem = new HashSet<CartItem>();
            InventoryItem = new HashSet<InventoryItem>();
        }

        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        public int StorageQuantity { get; set; }
        public int SoldQuantity { get; set; }
        public int? Rating { get; set; }

        [InverseProperty("Book")]
        public virtual ICollection<CartItem> CartItem { get; set; }
        [InverseProperty("Book")]
        public virtual ICollection<InventoryItem> InventoryItem { get; set; }
    }
}
