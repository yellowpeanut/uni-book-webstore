using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Application.ViewComponents
{
    public class BookCarouselViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<ViewModels.BookCardViewModel> books, string carouselId)
        {
            ViewBag.Id = carouselId;
            return View(books);
        }
    }
}
