using System.ComponentModel.DataAnnotations;

namespace DreamLife.Models
{
    public class HolidaysViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly HolidayDate { get; set; }
        public DateTime UpdatedDate { get; set;}

    }
}
