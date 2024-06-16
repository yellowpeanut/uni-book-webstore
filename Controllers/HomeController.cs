using Application.Data;
using Application.Data.Services;
using Application.Models;
using Application.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace uni_book_webstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly BookDataService _bookDataService;
        public readonly SignInManager<User> _signInManager;
        public readonly UserManager<User> _userManager;

        public HomeController(ApplicationContext context, BookDataService bookDataService,
            SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _context = context;
            _bookDataService = bookDataService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<BookData> userRecommendationData;
            IEnumerable<BookData> popularRecommendationData;
            if (_signInManager.IsSignedIn(User))
            {
                var userId = _userManager.GetUserId(User);
                userRecommendationData = await _bookDataService.GetRecommendedItems(userId);
                popularRecommendationData = await _bookDataService.GetRecommendedItems();
            }
            else
            {
                userRecommendationData = await _bookDataService.GetRecommendedItems();
                popularRecommendationData = userRecommendationData;
            }
            ViewData["IdRecommended"] = "recommendedCarousel";
            ViewData["IdPopular"] = "popularCarousel";
            var data = new List<IEnumerable<BookCardViewModel>> {
                Application.Data.Utils.BookDataHelper.StickBookDataToBookCardVM
                (_context, userRecommendationData),
                Application.Data.Utils.BookDataHelper.StickBookDataToBookCardVM
                (_context, popularRecommendationData)};
            return View(data);
        }
    }
}
