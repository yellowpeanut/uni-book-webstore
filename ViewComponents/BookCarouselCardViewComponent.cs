using Microsoft.AspNetCore.Mvc;

namespace Application.ViewComponents
{
    public class BookCarouselCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Models.BookData bookData, string postAuthor)
        {
            ViewBag.PostAuthor = postAuthor;
            return View(bookData);
        }

        [HttpPost]
        public IViewComponentResult AddToCart(Models.BookData bookData)
        {
            return View(bookData);
        }
    }
}
