using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addie.Dtos
{
    public class SaleToCreateDto
    {
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public IList<SaleItemDto> Items { get; set; }
    }
}