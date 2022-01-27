using Bookshop.Common;
using Bookshop.Infrastructure.ValidationAttributes.BooksValidationAttrubutes;
using System.ComponentModel.DataAnnotations;

namespace Bookshop.Web.Models.InputModels
{
    public class AddAuthorInputModel
    {
        [Required(ErrorMessage = "Name is required!")]
        [AuthorNameMaxLength(EntitiesConstants.AUTHOR_NAME_MAX_LENGTH)]
        [Display(Name = "Author Name")]
        public string? AuthorName { get; set; }
    }
}
