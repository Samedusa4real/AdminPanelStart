using Microsoft.AspNetCore.Mvc;
using PustokTemplate.DAL;
using PustokTemplate.Models;
using PustokTemplate.ViewModels;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace PustokTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly PustokDbContext _context;

        public HomeController(PustokDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                Sliders = _context.Sliders.OrderBy(x=>x.Order).ToList(),
                Features = _context.Features.ToList(),
                FeaturedBooks = _context.Books.Include(x=>x.Author).Include(x=>x.Images).Where(x=>x.IsFeatured).Take(10).ToList(),
                NewBooks = _context.Books.Include(x=>x.Author).Include(x => x.Images).Where(x => x.IsNew).Take(10).ToList(),
                DiscountedBooks = _context.Books.Include(x => x.Author).Include(x => x.Images).Where(x => x.DiscountPercent > 0).Take(10).ToList()
            };
            return View(homeViewModel);
        }

        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("bookCount", "5");
            return RedirectToAction("index");
        }

        public IActionResult GetSession()
        {
            var value = HttpContext.Session.GetString("bookCount");
            return Json(new { bookCount = value });
        }
    }
}