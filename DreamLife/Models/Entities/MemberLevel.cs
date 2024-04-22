using System.ComponentModel.DataAnnotations;

namespace DreamLife.Models.Entities
{
    public class MemberLevel
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string LevelId { get; set; }
        public string ParentId { get; set; }
        public string GrandParentId { get; set; }
        public string Position { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
