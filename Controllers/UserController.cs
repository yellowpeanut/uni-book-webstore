using Application.Data;
using Application.Data.Enums;
using Application.Data.Services;
using Application.Models;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace uni_book_webstore.Controllers
{
    public class UserController : Controller
    {
        public readonly UserService _userService;
        public readonly ApplicationContext _context;
        public readonly SignInManager<User> _signInManager;
        public readonly UserManager<User> _userManager;
        public readonly UserInventoryService _userInventoryService;
        public readonly InventoryItemService _inventoryItemService;
        public readonly UserCartService _userCartService;
        public readonly CartItemService _cartItemService;
        public readonly BookDataService _bookDataService;

        public UserController(UserService service,
        ApplicationContext context,
        UserInventoryService userInventoryService,
        InventoryItemService inventoryItemService,
        UserCartService userCartService,
        CartItemService cartItemService,
        BookDataService bookDataService,
        SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _userService = service;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _userInventoryService = userInventoryService;
            _inventoryItemService = inventoryItemService;
            _userCartService = userCartService;
            _cartItemService = cartItemService;
            _bookDataService = bookDataService;
        }

        [HttpGet]
        public async Task<IActionResult> LoginPartial()
        {
            // string str = HttpContext.Session.GetString("User");
            if (_signInManager.IsSignedIn(User))
            {
                // User user = User.Deserialize(str);
                User user = await _userManager.GetUserAsync(User);
                return PartialView(user);
            }
            else
            {
                return PartialView();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (await _userManager.FindByEmailAsync(user.Email) == null)
                {
                    user.Balance = 0;
                    var result = await _userService.AddAsync(user, Roles.User, _userManager);
                    if (result)
                    {
                        await _userManager.AddToRoleAsync(user, Roles.User);
                        return await Login(new LoginViewModel() 
                        { Email = user.Email, Password = user.Password });
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
        [HttpGet]
        public IActionResult Login()
        {
            if (_signInManager.IsSignedIn(User))
                return View("Home", "Index");
            else
                return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                var _user = await _userManager.FindByEmailAsync(loginUser.Email);
                if (_user != null)
                {
                    if (await _userManager.CheckPasswordAsync(_user, loginUser.Password))
                    {
                        var res = await _signInManager.PasswordSignInAsync(_user, loginUser.Password, false, false);
                        if (res.Succeeded)
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
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Inventory()
        {
            User user = await _userManager.GetUserAsync(User);
            UserInventory inventory = await _userInventoryService.GetByUserIdAsync(user.Id);
            var bookIds = (await _inventoryItemService.GetByInventoryIdAsync(inventory.Id))
                .Select(e => e.BookId).ToList();
            var bookData = await _bookDataService.GetByIdsAsync(bookIds);
            var entities = Application.Data.Utils.BookDataHelper.StickBookDataToBookCardVM(_context, bookData);
            
            return View(entities);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            User user = await _userManager.GetUserAsync(User);
            UserCart cart = await _userCartService.GetByUserIdAsync(user.Id);
            var bookIds = (await _cartItemService.GetByCartIdAsync(cart.Id))
                .Select(e => e.BookId).ToList();
            var bookData = await _bookDataService.GetByIdsAsync(bookIds);
            var entities = Application.Data.Utils.BookDataHelper.StickBookDataToBookCardVM(_context, bookData);
            
            return View(entities);
        }



    }
}
