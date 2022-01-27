using Bookshop.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Infrastructure.ValidationAttributes.BooksValidationAttrubutes
{
    public class TitleNameMaxLengthAttribute : ValidationAttribute
    {
        private string errorMessage = $"Book title cannot be longer than {EntitiesConstants.BOOK_NAME_MAX_LENGTH}.";
        private int maxLength;

        public TitleNameMaxLengthAttribute(int maxLength)
        {
            this.maxLength = maxLength;
        }

        protected override ValidationResult? IsValid(object? title, ValidationContext validationContext)
        {
            this.ErrorMessage = errorMessage;

            if (((string?)title)?.Length > maxLength)
            {
                return new ValidationResult(this.ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
