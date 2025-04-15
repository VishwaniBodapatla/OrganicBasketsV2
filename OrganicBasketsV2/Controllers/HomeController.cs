using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrganicBasketsV2.Models;
using Microsoft.EntityFrameworkCore;

namespace OrganicBasketsV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OrganicBasketsContext _context;

        public HomeController(ILogger<HomeController> logger, OrganicBasketsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                // Redirect to the desired page if already logged in
                return RedirectToAction("CustomerList", "Products");
            }
            else
            {
                // Fetch products from the database
                var products = await _context.Products.ToListAsync();
                return View(products);
            }

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
