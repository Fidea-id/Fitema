using FitemaAPI.Helpers;
using FitemaAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FitemaAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(
            ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetAllPlan()
        {
            try
            {
                var response = await _customerService.GetCustomers(1);
                if (response.Success)
                    return Ok(response);
                return BadRequest(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return StatusCode(500, new DefaultResponse { Message = e.Message, Success = false });
            }
        }
    }
}
