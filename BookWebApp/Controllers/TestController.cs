using BookWebApp.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookWebApp.Controllers
{
    public class TestController : Controller
    {
        public readonly IBookCategoryService _service;
        public TestController(IBookCategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
    }
}
