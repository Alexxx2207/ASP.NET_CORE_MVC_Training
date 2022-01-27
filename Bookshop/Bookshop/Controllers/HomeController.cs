using Bookshop.Models;
using Bookshop.Services.Authors;
using Bookshop.Web.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bookshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthorsService authorsService;

        public HomeController(ILogger<HomeController> logger, IAuthorsService authorsService)
        {
            _logger = logger;
            this.authorsService = authorsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AddAuthorInputModel name)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            authorsService.AddAuthor(name.AuthorName);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}