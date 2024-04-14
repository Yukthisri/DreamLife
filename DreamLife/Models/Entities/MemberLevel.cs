using System.ComponentModel.DataAnnotations;

namespace DreamLife.Models
{
    public class MemberLevel
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Level { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
