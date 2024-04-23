using System.ComponentModel.DataAnnotations;

namespace DreamLife.Models.Entities
{
    public class Queries
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public long PhoneNumber { get; set; }
        public string Text { get; set; }
    }
}
