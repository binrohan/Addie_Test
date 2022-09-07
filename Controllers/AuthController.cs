using Addie.Data.Interfaces;
using Addie.Dtos;
using Addie.Helpers;
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
        [ProducesResponseType(typeof(ApiResponse<LoginReturnDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<LoginReturnDto>>> GetToken([FromBody] LoginDto loginDto)
        {
            var user = await _unitOfWork.Repository<User>().SingleAsync(u => u.Username == loginDto.Username
                                                                             && u.Password == loginDto.Password);

            if (user is null) return NotFound(new ApiResponse(404, "User not found!"));

            var loginReturnDto = new LoginReturnDto()
            {
                Id = user.Id,
                Username = user.Username,
                Token = _tokenService.Create(user)
            };

            return Ok(new ApiResponse<LoginReturnDto>(200, loginReturnDto));
        }
    }
}

