using Microsoft.AspNetCore.Mvc;

namespace FitemaAPI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
