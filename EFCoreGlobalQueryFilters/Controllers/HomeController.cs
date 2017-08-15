using System.Diagnostics;
using System.Linq;
using EFCoreGlobalQueryFilters.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreGlobalQueryFilters.Controllers
{
    public class HomeController : Controller
    {
        private readonly PlaylistContext _context;

        public HomeController(PlaylistContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var playlists = _context.Playlists.OrderBy(p => p.Title);

            return View(playlists);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
