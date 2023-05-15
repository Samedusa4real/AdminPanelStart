using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PustokTemplate.DAL;
using PustokTemplate.Models;
using PustokTemplate.ViewModels;

namespace PustokTemplate.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SliderController : Controller
    {
        private readonly PustokDbContext _context;

        public SliderController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            var query = _context.Sliders.AsQueryable();

            return View(PaginatedList<Slider>.Create(query, page, 3));
        }
    }
}
