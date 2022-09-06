using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addie.Dtos
{
    public class SalesToReturnDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public double TotalAmount { get; set; }
        public IEnumerable<SalesItemToReturnDto> Items { get; set; }
    }
}