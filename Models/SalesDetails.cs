using System.ComponentModel.DataAnnotations;

namespace Addie.Models
{
    public class SalesDetails : BaseEntity
    {
        [Required]
        public int SaleId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Total { get; set; }

        // Navigation Properties
        // Although InMemory Db doesn't supports Relation
        public Sales Sales { get; set; }
    }
}