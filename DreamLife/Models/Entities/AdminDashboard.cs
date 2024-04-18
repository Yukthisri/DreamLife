namespace DreamLife.Models.Entities
{
    public class AdminDashboard
    {
        public int Members {  get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ROIAmount { get; set; }
        public decimal LevelAmount { get; set; }
        public decimal ReferalAmount { get; set;}
    }
}
