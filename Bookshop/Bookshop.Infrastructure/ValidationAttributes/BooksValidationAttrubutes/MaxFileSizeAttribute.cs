using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Infrastructure.ValidationAttributes.BooksValidationAttrubutes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private double maxSize;
        private string error = $"File is too big!";

        public MaxFileSizeAttribute(double maxSize)
        {
            this.maxSize = maxSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            
            if (file != null)
            {
                if (file.Length > maxSize)
                {
                    int countOfDivisions = 0;
                    double tempMaxSize = maxSize;
                    while (tempMaxSize >= 1024)
                    {
                        tempMaxSize /= 1024;
                        countOfDivisions++;
                    }
                    string size = " Bytes";

                    if (countOfDivisions == 1)
                    {
                        size = "KB";
                    }
                    else if (countOfDivisions == 2)
                    {
                        size = "MB";
                    }
                    else if (countOfDivisions == 3)
                    {
                        size = "GB";
                    }

                    this.ErrorMessage = error + $"  Max size is {tempMaxSize}{size}";
                    return new ValidationResult(this.ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
