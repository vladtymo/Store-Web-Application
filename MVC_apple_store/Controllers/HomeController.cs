using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MVC_apple_store.Models;
using System.Diagnostics;

namespace MVC_apple_store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhoneService phoneService;

        public HomeController(IPhoneService phoneService)
        {
            this.phoneService = phoneService;
        }

        public IActionResult Index()
        {
            return View(phoneService.GetAllPhones());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}