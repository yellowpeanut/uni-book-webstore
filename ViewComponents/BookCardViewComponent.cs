using Microsoft.AspNetCore.Mvc;

namespace Application.ViewComponents
{
    public class BookCardViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(Models.BookData bookData, string mode)
        {
            ViewBag.Mode = mode;
            return View(bookData);
        }

        public IViewComponentResult AddToCart(Models.BookData bookData, string mode)
        {
            ViewBag.Mode = mode;
            return View(bookData);
        }
    }
}
