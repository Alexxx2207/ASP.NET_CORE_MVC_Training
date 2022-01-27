using Bookshop.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Infrastructure.ValidationAttributes.BooksValidationAttrubutes
{
    public class AuthorNameMaxLengthAttribute : ValidationAttribute
    {
        private string errorMessage = $"Author name cannot be longer than {EntitiesConstants.AUTHOR_NAME_MAX_LENGTH}.";

        private int maxLength;
        public AuthorNameMaxLengthAttribute(int maxLength)
        {
            this.maxLength = maxLength;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            this.ErrorMessage = errorMessage;

            if (((string?)value)?.Length > maxLength)
            {
                return new ValidationResult(this.ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
