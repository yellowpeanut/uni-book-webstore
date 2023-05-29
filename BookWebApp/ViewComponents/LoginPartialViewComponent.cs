using BookWebApp.Data.Services.Interfaces;
using BookWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BookWebApp.ViewComponents
{
    public class LoginPartialViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string str = HttpContext.Session.GetString("User");
            if (str != null)
            {
                User user = Models.User.Deserialize(str);
                return View(user);
            }
            else
            {
                return View(new User());
            }
        }
    }
}
