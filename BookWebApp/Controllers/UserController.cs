using BookWebApp.Data.Services.Interfaces;
using BookWebApp.Models;
using BookWebApp.Data.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using BookWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace BookWebApp.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserService _userService;
        public readonly SignInManager<User> _signInManager;
        public readonly UserManager<User> _userManager;
        public readonly IUserInventoryService _userInventoryService;
        public readonly IInventoryItemService _inventoryItemService;
        public readonly IUserCartService _userCartService;
        public readonly ICartItemService _cartItemService;

        public UserController(IUserService service, 
        IUserInventoryService userInventoryService, 
        IInventoryItemService inventoryItemService, 
        IUserCartService userCartService, 
        ICartItemService cartItemService,
        SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _userService = service;
            _signInManager = signInManager;
            _userManager = userManager;
            _userInventoryService = userInventoryService;
            _inventoryItemService = inventoryItemService;
            _userCartService = userCartService;
            _cartItemService = cartItemService;
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
                    var result = await _userService.AddAsync(user, Role.User, _userManager);
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
            if(_signInManager.IsSignedIn(User))
                return View("Home", "Index");
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

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> InventoryAsync()
        {
            Models.User user = await _userManager.GetUserAsync(User);
            Models.UserInventory inventory = await _userInventoryService.GetByUserIdAsync(user.Id);
            var inventoryItems = (await _inventoryItemService.GetByInventoryIdAsync(inventory.Id)).ToList();
            return View(inventoryItems);
        }

        [Authorize]
        public async Task<IActionResult> CartAsync()
        {
            Models.User user = await _userManager.GetUserAsync(User);
            Models.UserCart cart = await _userCartService.GetByUserIdAsync(user.Id);
            var cartItems = (await _cartItemService.GetByCartIdAsync(cart.Id)).ToList();
            return View(cartItems);
        }



    }
}
