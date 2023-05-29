using BookWebApp.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookWebApp.Controllers
{
    public class TestController : Controller
    {
        public readonly IUserService _service;
        public TestController(IUserService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            await _service.GetAllAsync();
            return View();
        }
    }
}
