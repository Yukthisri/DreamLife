using System.ComponentModel.DataAnnotations;

namespace DreamLife.Models.Entities
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
    }
}
