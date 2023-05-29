﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

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
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [StringLength(64)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [StringLength(32)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно для заполнения")]
        [StringLength(64)]
        public string Email { get; set; }
        public int Balance { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserCart> UserCart { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserInventory> UserInventory { get; set; }

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
