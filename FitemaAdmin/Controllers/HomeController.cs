﻿using FitemaAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FitemaAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Dashboard";
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login","Auth");
            }
            return View();
        }

        public IActionResult Sales()
        {
            return View();
        }

        public IActionResult Widgets() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}