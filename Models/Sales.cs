using System.ComponentModel.DataAnnotations;

namespace Addie.Models
{
    public class Sales : BaseEntity
    {
        [MaxLength(55)]
        public string CustomerName { get; set; }
                        
        [MaxLength(15)]
        public string MobileNo { get; set; }
        public double TotalAmount { get; set; }

        // Navigation Properties
        // Although InMemory Db doesn't supports Relation
        public IEnumerable<SalesDetails> SalesDetails { get; set; }
    }
}