using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addie.Dtos
{
    public class SaleItemDto
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}