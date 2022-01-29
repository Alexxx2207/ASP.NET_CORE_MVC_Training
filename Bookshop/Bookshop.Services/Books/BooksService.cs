using Bookshop.Data;
using Bookshop.Models.DTO;
using BookShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Services.Books
{
    public class BooksService : IBooksService
    {
        private readonly ApplicationDbContext dbContext;

        public BooksService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBook(string title, IEnumerable<string> authors, DateTime publishedOn, int pages, string imagePath)
        {
            var book = new Book
            { 
                Guid = Guid.NewGuid().ToString(),
                Title = title,  
                PublishedOn = publishedOn,
                Pages = pages,
                ImagePath = imagePath
            };
            await dbContext.Books.AddAsync(book);

            foreach (var author in authors)
            {
                var bookAuthor = new BookAuthor
                { 
                    AuthorGuid = author,
                    BookGuid = book.Guid,
                };
                await dbContext.BooksAuthors.AddAsync(bookAuthor);

            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookViewModelDTO>> GetBooks()
        {
            var books = await Task.Run(() => dbContext.Books.Include(b=>b.BookAuthors).ThenInclude(ba => ba.Author).ToList());

            var resultBooks = books.Select(x => new BookViewModelDTO
            {
                Title = x.Title,
                PublishedOn = x.PublishedOn,
                Pages = x.Pages,
                ImagePath = x.ImagePath,
                AuthorsNames = x.BookAuthors.Select(ba => ba.Author.FullName)
            });

            return resultBooks;
        }
    }
}
