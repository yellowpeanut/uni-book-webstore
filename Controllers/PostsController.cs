using Application.Data;
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
        private readonly ApplicationContext _context;
        public PostsController(PostService postService, BookDataService bookDataService,
            UserService userService, UserManager<User> userManager,
            ApplicationContext context)
        {
            _postService = postService;
            _bookDataService = bookDataService;
            _userService = userService;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // var posts = await _postService.GetAllAsync();
            var bookData = await _bookDataService.GetAllAsync();
            // var users = await _userService.GetAllAsync();
            var entities = Application.Data.Utils.BookDataHelper.StickBookDataToBookCardVM(_context, bookData);

/*            foreach (var post in posts)
            {
                entities.Add(new PostViewModel() 
                { 
                    BookData = bookData.Where(b => b.Book.Id == post.BookId).First(),
                    User = users.Where(u => u.Id == post.UserId).First()
                });
            }*/

            return View(entities);
        }    

        [HttpGet]
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postService.GetByIdAsync((ulong)id);
            if (post == null)
            {
                return NotFound();
            }

            var bookData = await _bookDataService.GetByIdAsync(post.BookId);
            var user = await _userService.GetByIdAsync(post.UserId);
            var recommendedItems = await _bookDataService.GetRecommendedItems(post.UserId);
            var recommendedBookCards = Application.Data.Utils.BookDataHelper
                .StickBookDataToBookCardVM(_context, recommendedItems);
            PostViewModel postData = new PostViewModel()
            {
                BookCard = new BookCardViewModel(){
                    BookData = bookData,
                    User = user,
                    Price = post.Price,
                    ReleaseYear = post.ReleaseYear
                },
                RecommendedItems = recommendedBookCards
            };

            return View(postData);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddBookToCart(ulong? bookId)
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveBookFromCart(ulong? bookId)
        {
            return View();
        }
    }
}
