using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class BookAuthor
    {
        [Required]
        public string BookGuid { get; set; }
        public Book Book { get; set; }

        [Required]
        public string AuthorGuid { get; set; }
        public Author Author { get; set; }
    }
}
