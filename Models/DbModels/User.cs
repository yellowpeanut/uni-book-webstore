using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Application.Models
{
    public partial class User : IdentityUser
    {
/*        public User()
        {
            UserCart = new HashSet<UserCart>();
            UserInventory = new HashSet<UserInventory>();
            // UserRole = new HashSet<UserRole>();
        }*/

        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [StringLength(64)]
        public override string UserName { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [StringLength(32)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [StringLength(64)]
        [EmailAddress]
        public override string Email { get; set; }
        public int Balance { get; set; } = 0;

        // [InverseProperty(nameof(User))]
        // public virtual ICollection<UserCart> UserCart { get; set; }
        // [InverseProperty(nameof(User))]
        // public virtual ICollection<UserInventory> UserInventory { get; set; }
        // [InverseProperty("User")]
        // public virtual ICollection<UserRole> UserRole { get; set; }

        public virtual UserCart UserCart { get; set; }
        public virtual UserInventory UserInventory { get; set; }

        [InverseProperty(nameof(User))]
        public virtual ICollection<Post> Posts { get; set; }

        public string Serialize()
        {
            var data = JsonSerializer.Serialize(this);
            return data;
        }

        public static User Deserialize(string user)
        {
            var data = JsonSerializer.Deserialize<User>(user);
            return data;
        }
    }
}
