using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PustokTemplate.DAL;
using PustokTemplate.Models;
using PustokTemplate.ViewModels;

namespace PustokTemplate.Areas.Manage.Controllers
{
    [Area("manage")]
    public class TagController : Controller
    {
        private readonly PustokDbContext _context;

        public TagController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            var query = _context.Tags.AsQueryable();

            return View(PaginatedList<Tag>.Create(query, page, 4));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tag tagname)
        {
            _context.Tags.Add(tagname);
            _context.SaveChanges();

            return RedirectToAction("Index");   
        }
    }
}
