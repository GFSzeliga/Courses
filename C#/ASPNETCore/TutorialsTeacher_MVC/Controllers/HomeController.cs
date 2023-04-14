using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using TutorialsTeacher_MVC.Models;
using TutorialsTeacher_MVC.Views.Home;
using TutorialsTeacher_MVC.Views.Shared;

namespace TutorialsTeacher_MVC.Controllers
{
    [Log]
    public class HomeController : Controller, IExceptionFilter
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HandleException]
        public IActionResult Index()
        {
            ViewBag.Name = "Bill";
            ViewData["NextName"] = "Billobil";
            return View();
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

        public void OnException(ExceptionContext context)
        {
            throw new NotImplementedException();
        }
    }
}