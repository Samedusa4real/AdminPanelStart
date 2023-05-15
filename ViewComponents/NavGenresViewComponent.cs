using Microsoft.AspNetCore.Mvc;
using PustokTemplate.DAL;

namespace PustokTemplate.ViewComponents
{
    public class NavGenresViewComponent:ViewComponent
    {
        private readonly PustokDbContext _context;

        public NavGenresViewComponent(PustokDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var data = _context.Genres.ToList();
            return View(data);
        }
    }
}
