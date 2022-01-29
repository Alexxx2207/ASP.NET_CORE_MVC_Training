using Bookshop.Data;
using Bookshop.Models.DTO;
using BookShop.Models;
using BookShop.Models.Entities;
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

        public async Task AddAuthor(string name)
        {
            Author author = new Author()
            {
                FullName = name,
                Guid = Guid.NewGuid().ToString(),
            };
            await dbContext.Authors.AddAsync(author);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuthorGuidNameViewModelDTO>> GetAllAuthorsNames()
        {
            return await Task.Run(() => dbContext.Authors.ToList().Select(a => new AuthorGuidNameViewModelDTO { Guid = a.Guid, Name = a.FullName }));

        }
    }
}
