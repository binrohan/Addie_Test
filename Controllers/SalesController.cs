using Microsoft.AspNetCore.Mvc;

namespace Addie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        public SalesController()
        {
            
        }

        public Task<IActionResult> GetSales()
        {
            
            return null;
        }

        public Task<IActionResult> GetSale()
        {
            return null;
        }

        public Task<IActionResult> CreateSale()
        {
            return null;
        }
    }
}