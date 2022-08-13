using System.Security.Claims;
using AutoMapper;
using Fitema.Dtos;
using Fitema.Dtos.Auth;
using Fitema.Requests;
using Fitema.Services.Contracts;
using Fitema.Utils.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace SaveWinMalaysia.Controllers
{
    public class AuthController : Controller
    {
        /// <summary>
        /// This controller is for Auth only, login, decide user role access and etc.
        /// </summary>
        /// <returns></returns>
        
        private readonly ILogger<AuthController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        public AuthController(
            ILogger<AuthController> logger,
            IMapper mapper,
            IAuthService authService
	    )
        {
            _logger = logger;
            _mapper = mapper;
            _authService = authService;

        }

        [Route("~/Login")]
        [Route("~/Auth")]
        [HttpGet]
        public IActionResult Index(string? returnUrl)
        {
            if (HttpContext.User.Identity!.IsAuthenticated)
            {
                var user = HttpContext.User;
                if(user.IsInRole(RoleOfUser.ADMIN)){
                    return Redirect("/admin/dashboard");
                }
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [Route("~/AccessDenied")]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [Route("~/NotFound")]
        [HttpGet]
        public IActionResult NotFound()
        {
            ViewData["Layout"] = "_Layout";
            ViewData["HomeURL"] = "/";
            if (HttpContext.User.Identity!.IsAuthenticated)
            {
                ViewData["Layout"] = "_AuthLayout";
                ViewData["HomeURL"] = "/Auth";
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Auth");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginRequest request)
        {
            try {

			    var user = _mapper.Map<LoginDto>(request);
			    (ResponseDto result, ClaimsPrincipal? claimsPrincipal) = await _authService.Login(user);
			    if (result.Success) { 
				    await HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties { IsPersistent = request.RememberMe ?? false});
                    var role = claimsPrincipal.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value).FirstOrDefault();

                    if (!string.IsNullOrEmpty(request.ReturnUrl))
                    {
                        return Ok(request.ReturnUrl);
                    }
                    if(role == RoleOfUser.ADMIN)
                    {
                        return Ok("/Admin/Dashboard");
                    }
                }
			    return BadRequest(result);
	        } catch (Exception e) {
                _logger.LogError(e.ToString());
                return StatusCode(500);
	        }
        }

        [HttpGet]
        public string GenPassword(string password) 
		{
            return _authService.GenPassword(password); 
	    }
    }
}