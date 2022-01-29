using Bookshop.Models.DTO;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Services.Books
{
    public interface IBooksService
    {
        Task AddBook(string title, IEnumerable<string> authors, DateTime publishedOn, int pages, string ImagePath);

        Task<IEnumerable<BookViewModelDTO>> GetBooks();
    }
}
