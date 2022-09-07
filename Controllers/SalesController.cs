using Addie.Data.Interfaces;
using Addie.Dtos;
using Addie.Helpers;
using Addie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Addie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SalesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISalesRepository _repo;
        public SalesController(IUnitOfWork unitOfWork, ISalesRepository repo)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<Sales>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSales()
        {
           var sales = await _unitOfWork.Repository<Sales>().ListAllAsync();

           return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale([FromRoute]int id)
        {
            var sales = await _unitOfWork.Repository<Sales>().GetByIdAsync(id);
            
            if(sales is null) return NotFound();
            
            var salesItems = await _unitOfWork.Repository<SalesDetails>().ListAsync(i => i.SaleId == id);

            var salesToReturn = new SalesToReturnDto()
            {
                CustomerName = sales.CustomerName,
                Id = sales.Id,
                MobileNo = sales.MobileNo,
                TotalAmount = sales.TotalAmount,
                Items = salesItems.Select(item => new SalesItemToReturnDto()
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Total = item.Total
                })
            };

            return Ok(salesToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody]SaleToCreateDto salesToCreateDto)
        {
            var salesToCreate = new Sales()
            {
                CustomerName = salesToCreateDto.CustomerName,
                MobileNo = salesToCreateDto.MobileNo,
                TotalAmount = salesToCreateDto.Items.Sum(p => p.Quantity * p.UnitPrice),
            };

            _unitOfWork.Repository<Sales>().Add(salesToCreate);

            var salesItems = new List<SalesDetails>();

            foreach (var product in salesToCreateDto.Items)
            {
                salesItems.Add(new SalesDetails(){
                    ProductId = product.ProductId,
                    Quantity = product.Quantity,
                    SaleId = salesToCreate.Id,
                    UnitPrice = product.UnitPrice,
                    Total = product.Quantity * product.UnitPrice
                });
            }

            _unitOfWork.Repository<SalesDetails>().AddRange(salesItems);

            var result = await _unitOfWork.Complete();

            if(result <= 0) return BadRequest("Sales cannot be created!");

            return Ok(new {Id = salesToCreate.Id});
        }
    }
}