using Bookshop.Common;
using System.ComponentModel.DataAnnotations;
using Bookshop.Infrastructure.ValidationAttributes.BooksValidationAttrubutes;
using Bookshop.Infrastructure.ModelBinders.BooksModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookshop.Web.Models.InputModels
{
    public class AddBookInputModel : IValidatableObject
    {
        [Required(ErrorMessage = "Title is required!")]
        [TitleNameMaxLength(EntitiesConstants.BOOK_NAME_MAX_LENGTH)]
        public string Title { get; set; }

        [Display(Name = "Author Name")]
        [Required(ErrorMessage = "Author is required!")]
        public string AuthorsNames { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Published On")]
        [Required(ErrorMessage = "Pages are required!")]
        public DateTime? PublishedOn { get; set; }

        [Required(ErrorMessage = "Pages are required!")]
        //[ModelBinder(typeof(BooksPagesModelBinder))]
        // ^^^^^^ WE CAN REMOVE THIS ATTRIBUTE BECAUSE
        // |||||| WE HAVE REGISTERED A MODEL BINDING PROVIDER
        // |||||| FOR THIS CUSTOM MODEL BINDER
        public int? Pages { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        [MaxFileSize(EntitiesConstants.MAX_SIZE_ALLOWED)]
        public IFormFile? Image { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PublishedOn > DateTime.UtcNow)
            {
                yield return new ValidationResult("Book cannot be published in the future!"); 
            }

            if (Pages <= 0)
            { 
                yield return new ValidationResult("Book with non-positive pages cannot be added!");
            }
        }
    }
}
