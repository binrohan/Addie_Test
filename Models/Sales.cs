namespace Addie.Models
{
    public class Sales : BaseEntity
    {
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public double TotalAmount { get; set; }

        // Navigation Properties
        // Although InMemory Db doesn't supports Relation
        public IEnumerable<SalesDetails> SalesDetails { get; set; }
    }
}