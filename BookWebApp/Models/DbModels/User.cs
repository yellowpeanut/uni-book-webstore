using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookWebApp.Models
{
    public partial class User
    {
        public User()
        {
            UserCart = new HashSet<UserCart>();
            UserInventory = new HashSet<UserInventory>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Username { get; set; }
        [Required]
        [StringLength(32)]
        public string Password { get; set; }
        [Required]
        [StringLength(64)]
        public string Email { get; set; }
        public int Balance { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserCart> UserCart { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserInventory> UserInventory { get; set; }
    }
}
