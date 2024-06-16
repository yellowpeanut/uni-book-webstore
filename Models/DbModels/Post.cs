using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Application.Models
{
    public partial class Post
    {

        [Key]
        public ulong Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public ulong BookId { get; set; }
        [Required]
        public uint Price { get; set; }
        [Required]
        public ushort ReleaseYear { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }

    }
}
