using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookWebApp.Models
{
    public partial class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty("CartItem")]
        public virtual Book Book { get; set; }
        [ForeignKey(nameof(CartId))]
        [InverseProperty(nameof(UserCart.CartItem))]
        public virtual UserCart Cart { get; set; }
    }
}
