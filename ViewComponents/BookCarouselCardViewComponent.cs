using Microsoft.AspNetCore.Mvc;

namespace Application.ViewComponents
{
    public class BookCarouselCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ViewModels.PostViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IViewComponentResult AddToCart(ViewModels.PostViewModel model)
        {
            return View(model);
        }
    }
}
