using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Services.Authors
{
    public interface IAuthorsService
    {
        IEnumerable<string> GetAllAuthorsNames();

        void AddAuthor(string name);
    }
}
