using Addie.Data.Interfaces;
using Addie.Dtos;
using Addie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Addie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        public AuthController(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }
        

        [HttpPost]
        public async Task<IActionResult> GetToken([FromBody]LoginDto loginDto)
        {
            var user = await _unitOfWork.Repository<User>().SingleAsync(u => u.Username == loginDto.Username
                                                                             && u.Password == loginDto.Password);

            if (user is null) return NotFound("Username and Password combination doesn't matched!");


            return Ok(new LoginReturnDto(){
                Id = user.Id,
                Username = user.Username,
                Token = _tokenService.Create(user)
            });
        }
    }
}