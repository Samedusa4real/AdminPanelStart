using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokTemplate.DAL;
using PustokTemplate.Models;
using PustokTemplate.ViewModels;

namespace PustokTemplate.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BookController : Controller
    {
        private readonly PustokDbContext _context;

        public BookController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1, string search = null)
        {
            var query = _context.Books
                .Include(x => x.Author).Include(x => x.Genre).AsQueryable();

            if (search != null)
                query = query.Where(x => x.Name.Contains(search));


            ViewBag.SearchValue = search;

            return View(PaginatedList<Book>.Create(query, page, 3));
        }
    }
}
