using Bookshop.Infrastructure.ModelBinders.BooksModelBinders;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;


namespace Bookshop.Web.ModelBinderProviders
{
    public class BooksPagesModelBinderProviders : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.Metadata.PropertyName?.ToLower() == "pages")
            {
                return new BinderTypeModelBinder(typeof(BooksPagesModelBinder));
            }
            return null;
        }
    }
}
