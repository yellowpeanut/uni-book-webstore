using BookWebApp.Data.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BookWebApp.Controllers
{
    public class CatalogController : Controller
    {
        public readonly IBookDataService _service;
        public CatalogController(IBookDataService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            Debug.WriteLine(data);
            return View(data);
        }
    }
}
