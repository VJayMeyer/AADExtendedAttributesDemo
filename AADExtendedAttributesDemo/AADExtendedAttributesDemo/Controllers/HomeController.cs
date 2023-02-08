using AADExtendedAttributesDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AADExtendedAttributesDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///     Show Cliams
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("claims")]
        public ViewResult Claims() => View(User?.Claims);

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "SuperMan")]
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