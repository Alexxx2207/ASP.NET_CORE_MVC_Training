using Bookshop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Services.Authors
{
    public interface IAuthorsService
    {
        Task<IEnumerable<AuthorGuidNameViewModelDTO>> GetAllAuthorsNames();

        Task AddAuthor(string name);
    }
}
