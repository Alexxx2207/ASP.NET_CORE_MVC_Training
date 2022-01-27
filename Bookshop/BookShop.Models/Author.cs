using Bookshop.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Author
    {
        public Author()
        {
            AuthorBooks = new HashSet<BookAuthor>();
        }

        [Key]
        [Required]
        public string Guid { get; set; }

        [Required]
        [MaxLength(EntitiesConstants.AUTHOR_NAME_MAX_LENGTH)]
        public string FullName { get; set; }

        public ICollection<BookAuthor> AuthorBooks { get; set; }
    }
}
