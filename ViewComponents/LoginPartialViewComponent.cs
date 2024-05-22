using Microsoft.AspNetCore.Mvc;


namespace Application.ViewComponents
{
    public class LoginPartialViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
