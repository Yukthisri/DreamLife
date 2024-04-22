using System.ComponentModel.DataAnnotations;

namespace DreamLife.Models
{
    public class RegistrationViewModel
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateOnly DateofBirth { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public int Phone { get; set; }
        public string City { get; set; }
        public string ReferalCode { get; set; } = string.Empty;
    }
}
