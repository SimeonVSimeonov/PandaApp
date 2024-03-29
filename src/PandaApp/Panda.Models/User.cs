﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Panda.Models
{
    public class User
    {
        public User()
        {
            this.Packages = new HashSet<Package>();
            this.Receipts = new HashSet<Receipt>();
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [Range(5, 20)]
        public string Username { get; set; }

        [Required]
        [Range(5, 20)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Package> Packages { get; set; } //virtual  ???

        public ICollection<Receipt> Receipts { get; set; } //virtual  ???
    }
}
