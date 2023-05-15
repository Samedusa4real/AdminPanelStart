using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PustokTemplate.DAL;
using PustokTemplate.Models;
using PustokTemplate.ViewModels;

namespace PustokTemplate.Controllers
{
    public class BookController : Controller
    {
        private readonly PustokDbContext _context;

        public BookController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult GetBookDetail(int id)
        {
            Book book = _context.Books
                .Include(x => x.Author)
                .Include(x => x.Images)
                .Include(x => x.BookTags).ThenInclude(x => x.Tag)
                .FirstOrDefault(x => x.Id == id);

            return PartialView("_BookModalPartial", book);
        }

        public IActionResult AddToBasket(int id)
        {
            List<BasketItemCountViewModel> cookieItems = new List<BasketItemCountViewModel>();
            BasketItemCountViewModel cookieItem; 

            var basketStr = Request.Cookies["basket"];
            if (basketStr != null)
            {
                cookieItems = JsonConvert.DeserializeObject<List<BasketItemCountViewModel>>(basketStr);

                cookieItem = cookieItems.FirstOrDefault(x => x.BookId == id);

                if (cookieItem != null)
                {
                    cookieItem.Count++;
                }
                else
                {
                    cookieItem = new BasketItemCountViewModel
                    {
                        BookId = id,
                        Count = 1
                    };
                    cookieItems.Add(cookieItem);
                }
            }
            else
            {
                cookieItem = new BasketItemCountViewModel
                {
                    BookId = id,
                    Count = 1
                };
                cookieItems.Add(cookieItem);
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(cookieItems));

            BasketViewModel bv = new BasketViewModel();

            foreach (var ci in cookieItems)
            {
                BasketItemViewModel bi = new BasketItemViewModel
                {
                    Count = ci.Count,
                    Book = _context.Books.Include(x => x.Images).FirstOrDefault(x => x.Id == ci.BookId),
                };
                bv.BasketItems.Add(bi);
                bv.TotalPrice += (bi.Book.DiscountPercent > 0 ? (bi.Book.InitialPrice * (100 - bi.Book.DiscountPercent) / 100) : bi.Book.InitialPrice) * bi.Count;
            }

            return PartialView("_BasketPartialView", bv);
        }

        public IActionResult AddAndRemoveBasket(int id)
        {
            List<int> ids = new List<int>();

            var basketStr = Request.Cookies["basket"];
            if (basketStr != null)
            {
                ids = JsonConvert.DeserializeObject<List<int>>(basketStr);
            }

            if (ids.Contains(id))
            {
                ids.Remove(id);
            }
            else
            {
                ids.Add(id);
            }

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(ids));
            return RedirectToAction("index", "home");
        }

        public IActionResult ShowBasket()
        {
            var basketStr = Request.Cookies["basket"];
            var basketVal = JsonConvert.DeserializeObject<List<BasketItemCountViewModel>>(basketStr);
            return Json(new { basketVal });
        }

        public IActionResult RemoveFromBasket(int id)
        {
            List<BasketItemCountViewModel> cookieItems = new List<BasketItemCountViewModel>();
            BasketItemCountViewModel cookieItem;

            var basketStr = Request.Cookies["basket"];

            if (basketStr == null)
                return NotFound();

            cookieItems = JsonConvert.DeserializeObject<List<BasketItemCountViewModel>>(basketStr);

            var item = cookieItems.FirstOrDefault(x => x.BookId == id);

            if (item == null)
                return StatusCode(404);

            if (item.Count > 1)
                item.Count--;
            else
                cookieItems.Remove(item);

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(cookieItems));

            BasketViewModel bv = new BasketViewModel();

            foreach (var ci in cookieItems)
            {
                BasketItemViewModel bi = new BasketItemViewModel
                {
                    Count = ci.Count,
                    Book = _context.Books.Include(x => x.Images).FirstOrDefault(x => x.Id == ci.BookId),
                };
                bv.BasketItems.Add(bi);
                bv.TotalPrice += (bi.Book.DiscountPercent > 0 ? (bi.Book.InitialPrice * (100 - bi.Book.DiscountPercent) / 100) : bi.Book.InitialPrice) * bi.Count;
            }

            return PartialView("_BasketPartialView", bv);
        }
    }
}
