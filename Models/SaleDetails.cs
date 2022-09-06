namespace Addie.Models
{
    public class SaleDetails
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Total { get; set; }

        // Navigation Properties
        public Sale Sale { get; set; }
    }
}