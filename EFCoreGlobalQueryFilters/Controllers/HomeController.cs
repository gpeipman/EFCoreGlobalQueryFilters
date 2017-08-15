using System.Diagnostics;
using EFCoreGlobalQueryFilters.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreGlobalQueryFilters.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
