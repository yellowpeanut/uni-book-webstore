using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Application.Models
{
    public partial class UserCart
    {
/*        public UserCart()
        {
            CartItems = new HashSet<CartItem>();
        }*/

        [Key]
        public ulong Id { get; set; }
        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        // [InverseProperty("UserCart")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(UserCart))]
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
