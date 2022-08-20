using FitemaAPI.Helpers;
using FitemaAPI.Services.Contracts;
using FitemaEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitemaAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BillsController : Controller
    {
        private IBillService _billService;
        private readonly ILogger<BillsController> _logger;

        public BillsController(
            ILogger<BillsController> logger, IBillService billService)
        {
            _logger = logger;
            _billService = billService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var userLogged = (Users)HttpContext.Items["User"];
                var response = await _billService.GetOrgBills(userLogged.Id);
                return Ok(response);
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
