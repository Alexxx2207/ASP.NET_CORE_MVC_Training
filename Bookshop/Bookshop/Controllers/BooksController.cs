using Bookshop.Data;
using Bookshop.Services.Authors;
using Bookshop.Web.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookshop.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IAuthorsService authorsService;

        public BooksController(IAuthorsService authorsService)
        {
            this.authorsService = authorsService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddBookInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return Redirect("ListAllBooks");
        }

        public IActionResult ListAllBooks()
        {
            return View();
        }
    }
}
