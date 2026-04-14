using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AlpineHub.Web.Infrastructure.Binders
{
    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        private readonly string customFormat;
        public DateTimeModelBinderProvider(string _customFormat)
        {
            customFormat = _customFormat;
        }
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            if (context.Metadata.ModelType == typeof(DateTime) || context.Metadata.ModelType == typeof(DateTime?))
            {
                return new DateTimeModelBinder(customFormat);
            }
            return null;
        }
    }
}
