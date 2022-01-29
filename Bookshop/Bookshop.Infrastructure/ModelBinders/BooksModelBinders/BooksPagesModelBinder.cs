using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.Infrastructure.ModelBinders.BooksModelBinders
{
    public class BooksPagesModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue("Pages").FirstValue;

            if (int.TryParse(value, out int pages))
            {
                pages += 2; 
                bindingContext.Result = ModelBindingResult.Success(pages);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }
            return Task.CompletedTask;
        }
    }
}
