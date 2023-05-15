using Microsoft.AspNetCore.Mvc;

namespace PustokTemplate.Areas.Manage.Controllers
{
    [Area("manage")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
