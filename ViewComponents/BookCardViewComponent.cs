using Microsoft.AspNetCore.Mvc;

namespace Application.ViewComponents
{
    public class BookCardViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(ViewModels.BookCardViewModel model, string mode)
        {
            ViewBag.Mode = mode;
            return View(model);
        }

        public IViewComponentResult AddToCart(ViewModels.BookCardViewModel model, string mode)
        {
            ViewBag.Mode = mode;
            return View(model);
        }
    }
}
