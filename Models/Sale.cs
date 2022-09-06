namespace Addie.Models
{
    public class Sale
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public double TotalAmount { get; set; }
    }
}