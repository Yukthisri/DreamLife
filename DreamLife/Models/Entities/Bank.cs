using System.ComponentModel.DataAnnotations;

namespace DreamLife.Models
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string AccountName { get; set; }
        public int AccountNumber { get; set; }
        public string IFSC { get; set; }
    }
}
