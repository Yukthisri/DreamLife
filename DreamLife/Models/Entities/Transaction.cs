﻿using System.ComponentModel.DataAnnotations;

namespace DreamLife.Models.Entities
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Amount { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
