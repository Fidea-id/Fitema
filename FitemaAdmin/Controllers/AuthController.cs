using FitemaAdmin.Services;
using FitemaAdmin.Services.Contracts;
using FitemaAdmin.Utils.Helpers;
using FitemaEntity.Requests;
using FitemaEntity.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FitemaAdmin.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        #region Pages
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }
        public IActionResult Register()
        {
            ViewData["Title"] = "Register";
            return View();
        }

        public new IActionResult NotFound() => View();

        public IActionResult InternalError() => View();

        public IActionResult LockScreen() => View();

        public IActionResult RecoverPassword() => View();
        #endregion

        #region Function

        public async Task<IActionResult> SignIn(LoginRequest request)
        {
            try
            {
                var response = await _authService.SignIn(request);


                var now = DateTime.UtcNow;


                var localDate = now.ToLocalTime();


                return Ok(response);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IActionResult> CreateAccount(CreateUserRequest request)
        {
            try
            {
                var response = await _authService.CreateUser(request);
                return Ok(response);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //forgot password
        //resend email verification
        #endregion
    }
}
