using Bookshop.Data;
using Bookshop.Services.Authors;
using Bookshop.Services.Books;
using Bookshop.Web.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookshop.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IAuthorsService authorsService;
        private readonly IBooksService booksService;
        private readonly IWebHostEnvironment environment;

        public BooksController(IAuthorsService authorsService, IBooksService booksService, IWebHostEnvironment environment)
        {
            this.authorsService = authorsService;
            this.booksService = booksService;
            this.environment = environment;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string tillwwwroot = environment.WebRootPath;
            string afterwwwroot = "uploads";
            string filePath = "";
            string imagePathForDB = "";
            var file = inputModel.Image;
           
                if (file?.Length > 0)
                {
                    filePath = Path.Combine(tillwwwroot, afterwwwroot, file.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    imagePathForDB = "/" + Path.Combine(afterwwwroot, file.FileName).Replace("\\", "/");
                }

                
                await booksService.AddBook(inputModel.Title, inputModel.AuthorsNames, inputModel.PublishedOn.Value, inputModel.Pages.Value, imagePathForDB);

            return Redirect("ListAllBooks");
        }

        public IActionResult ListAllBooks()
        {
            var model = booksService.GetBooks().Result;
            return View(model);
        }
    }
}
