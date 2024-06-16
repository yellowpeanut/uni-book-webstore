using Microsoft.AspNetCore.Mvc;

namespace Application.ViewComponents
{
    public class BookCarouselCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ViewModels.BookCardViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IViewComponentResult AddToCart(ViewModels.BookCardViewModel model)
        {
            return View(model);
        }
    }
}
