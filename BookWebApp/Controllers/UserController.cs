using BookWebApp.Data.Services.Interfaces;
using BookWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookWebApp.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        public IActionResult LoginPartial()
        {
            string str = HttpContext.Session.GetString("User");
            if(str != null) 
            {
                User user = Models.User.Deserialize(str);
                return PartialView(user);
            }
            else
            {
                return PartialView();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if(user.Username != null && user.Password != null && user.Email != null)
            {
                if (await _service.GetByEmailAsync(user.Email) == null)
                {
                    user.Balance = 0;
                    await _service.AddAsync(user);
                    return await Login(user);
                }
                else
                {
                    ViewBag.Message = "Пользователь с таким адресом электронной почты уже зарегистрирован.";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Для регистрации необходимо заполнить все поля.";
                return View();
            }

        }

        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("User") != null)
                return View();
            else
                return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var _user = await _service.GetByEmailAsync(user.Email);
            if(_user != null)
            {
                if(_user.Password == user.Password)
                {
                    HttpContext.Session.SetString("User", _user.Serialize());                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Пароль введен неверно";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Пользователь с такими данными не найден";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Profile()
        {
            if(HttpContext.Session.GetString("User") != null)
                return View(Models.User.Deserialize(HttpContext.Session.GetString("User")));
            else
                return View("Login");
        }

        public IActionResult Inventory()
        {
            if(HttpContext.Session.GetString("User") != null)
                return View(Models.User.Deserialize(HttpContext.Session.GetString("User")));
            else
                return View("Login");
        }

        public IActionResult Cart()
        {
            if(HttpContext.Session.GetString("User") != null)
                return View(Models.User.Deserialize(HttpContext.Session.GetString("User")));
            else
                return View("Login");
        }



    }
}
