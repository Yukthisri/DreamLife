﻿using System.ComponentModel.DataAnnotations;

namespace DreamLife.Models.Entities
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role {  get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
