using Bookshop.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        [Key]
        [Required]
        public string Guid { get; set; }

        [Required]
        [MaxLength(EntitiesConstants.BOOK_NAME_MAX_LENGTH)]
        public string Title { get; set; }

        public int Pages { get; set; }

        public DateTime PublishedOn { get; set; }

        public string ImagePath { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
