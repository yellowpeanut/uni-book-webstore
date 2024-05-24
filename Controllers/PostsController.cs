using Application.Data.Services;
using Application.Models;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace uni_book_webstore.Controllers
{
    public class PostsController : Controller
    {
        private readonly PostService _postService;
        private readonly BookDataService _bookDataService;
        private readonly UserService _userService;
        private readonly UserManager<User> _userManager;
        public PostsController(PostService postService, BookDataService bookDataService,
            UserService userService, UserManager<User> userManager)
        {
            _postService = postService;
            _bookDataService = bookDataService;
            _userService = userService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index(ulong id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            var bookData = await _bookDataService.GetByIdAsync(post.BookId);
            var user = await _userService.GetByIdAsync(post.UserId);
            var recommendedItems = await _bookDataService.GetRecommendedItems(post.UserId);

            PostViewModel postData = new PostViewModel()
            {
                BookData = bookData,
                User = user,
                RecommendedItems = recommendedItems
            };

            return View(postData);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
