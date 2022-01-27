using Bookshop.Data;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Services.Authors
{
    public class AuthorsService : IAuthorsService
    {
        private ApplicationDbContext dbContext;
        public AuthorsService(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        public void AddAuthor(string name)
        {
            Author author = new Author()
            {
                FullName = name,
                Guid = Guid.NewGuid().ToString(),
            };
            dbContext.Authors.Add(author);
            dbContext.SaveChanges();
        }

        public IEnumerable<string> GetAllAuthorsNames()
        {
            return dbContext.Authors.Select(a => a.FullName).ToList();

        }
    }
}
