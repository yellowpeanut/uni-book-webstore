using BookWebApp.Data.Services.Interfaces;
using BookWebApp.Models;
using BookWebApp.Data.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using BookWebApp.ViewModels;

namespace BookWebApp.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserService _service;
        public readonly SignInManager<User> _signInManager;
        public readonly UserManager<User> _userManager;
        public UserController(IUserService service, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _service = service;
            _signInManager = signInManager;
            _userManager = userManager;
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
            if(ModelState.IsValid)
            {
                if (await _userManager.FindByEmailAsync(user.Email) == null)
                {
                    user.Balance = 0;
                    var result = await _service.AddAsync(user, Role.User, _userManager);
                    if(result)
                    {
                        await _userManager.AddToRoleAsync(user, Role.User);
                        return await Login(new LoginViewModel(){ Email = user.Email, Password = user.Password });
                    }
                    else
                    {
                        ViewBag.Message = "Произошла непредвиденная ошибка, повторите действие позже.";
                        return View();
                    }
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
            /*_signInManager.IsSignedIn(ClaimsPrincipal.Current)*/
            if(true)
                return View();
            else
                return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginUser)
        {
            if(ModelState.IsValid)
            {
                var _user = await _userManager.FindByEmailAsync(loginUser.Email);
                if (_user != null)
                {
                    if(await _userManager.CheckPasswordAsync(_user, loginUser.Password))
                    {
                        var res = await _signInManager.PasswordSignInAsync(_user, loginUser.Password, false, false);
                        if(res.Succeeded)                  
                            return RedirectToAction("Index", "Home");
                        else
                        {
                            ViewBag.Message = "Произошла непредвиденная ошибка, повторите действие позже.";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Пароль введен неверно";
                        return View();
                    }
                }
            }
            ViewBag.Message = "Пользователь с такими данными не найден";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
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
