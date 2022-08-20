using FitemaAPI.Helpers;
using FitemaAPI.Services.Contracts;
using FitemaEntity.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FitemaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(LoginRequest model)
        {
            try
            {
                var response = await _authService.Authenticate(model);
                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, new DefaultResponse { Message = e.Message, Success = false });
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserRequest model)
        {
            try
            {
                var response = await _authService.Register(model);
                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, new DefaultResponse { Message = e.Message, Success = false});
            }
        }
    }
}
