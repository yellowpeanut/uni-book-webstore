using BookWebApp.Data.Services;
using BookWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookWebApp.Controllers
{
    public class UserController : Controller
    {
        public readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if(await _service.GetByEmailAsync(user.Email) == null) 
            {
                user.Balance = 0;
                await _service.AddAsync(user);
                return RedirectToAction("Login", user);
            }
            else
            {
                ViewBag.Message = "Пользователь с таким адресом электронной почты уже зарегистрирован.";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var _user = await _service.GetByEmailAsync(user.Email);
            if(_user != null)
            {
                HttpContext.Session.SetInt32("UserId", _user.Id);
                HttpContext.Session.SetString("Username", _user.Username);
                return View("./Home/Index");
            }
            else
            {
                ViewBag.Message = "Пользователь с такими данными не найден";
                return View("Login");
            }


        }
    }
}
