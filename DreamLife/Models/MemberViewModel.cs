using System.ComponentModel.DataAnnotations;

namespace DreamLife.Models
{
    public class MemberViewModel
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
    }
}
