using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Models.DTO
{
    public class BookViewModelDTO
    {
        public string Title { get; set; }

        public IEnumerable<string> AuthorsNames { get; set; }

        public int Pages { get; set; }

        public DateTime PublishedOn { get; set; }

        public string ImagePath { get; set; }
    }
}
