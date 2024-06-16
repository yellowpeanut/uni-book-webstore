using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Application.ViewComponents
{
    public class BookListViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<ViewModels.BookCardViewModel> model, string mode)
        {
            ViewBag.Mode = mode;
            return View(model);
        }
    }
}
