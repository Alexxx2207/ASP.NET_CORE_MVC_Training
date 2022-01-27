using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Infrastructure.ValidationAttributes.BooksValidationAttrubutes
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private string[] extensions;
        private string error = $"Invalid file type. Allowed: jpg, jpeg, png";
        public AllowedExtensionsAttribute(string[] extensions)
        {
            this.extensions = extensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            { 
                var extension = Path.GetExtension(file.FileName);
                if (!extensions.Contains(extension.ToLower()))
                {
                    this.ErrorMessage = error;
                    return new ValidationResult(this.ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
