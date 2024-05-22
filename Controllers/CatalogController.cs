using Application.Data.Services;
using Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace uni_book_webstore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly BookDataService _bookDataService;
        private readonly UserService _userService;
        public readonly SignInManager<User> _signInManager;
        public readonly UserManager<User> _userManager;
        public CatalogController(BookDataService bookDataService, UserService userService,
            SignInManager<User> signInManager, UserManager<User> userManager) 
        {
            _bookDataService = bookDataService;
            _userService = userService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _bookDataService.GetAllAsync();
            IEnumerable<BookData> recommendationData;
            if (_signInManager.IsSignedIn(User))
            {
                var userId = _userManager.GetUserId(User);
                recommendationData = await _bookDataService.GetRecommendedItems(userId);
            }
            else
            {
                recommendationData = await _bookDataService.GetRecommendedItems();
            }

            return View(new List<IEnumerable<BookData>>() { data, recommendationData });
        }
    }
}
