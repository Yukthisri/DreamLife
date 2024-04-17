﻿using System.ComponentModel.DataAnnotations;

namespace DreamLife.Models
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
