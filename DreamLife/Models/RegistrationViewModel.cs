using System.ComponentModel.DataAnnotations;

namespace DreamLife.Models
{
    public class RegistrationViewModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateOnly DateofBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}
