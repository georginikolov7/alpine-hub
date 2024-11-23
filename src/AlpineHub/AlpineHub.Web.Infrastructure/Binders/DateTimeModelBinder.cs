
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace AlpineHub.Web.Infrastructure.Binders
{
    public class DateTimeModelBinder : IModelBinder
    {
        private readonly string customFormat;
        public DateTimeModelBinder(string _customFormat)
        {
            customFormat = _customFormat;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value != ValueProviderResult.None && string.IsNullOrEmpty(value.FirstValue))
            {
                string valueString = value.FirstValue;

                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);
                bool success = false;
                if (!DateTime.TryParseExact(valueString, customFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    try
                    {
                        result = DateTime.Parse(valueString, new CultureInfo("bg-bg").DateTimeFormat);
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex, bindingContext.ModelMetadata);
                    }
                }

                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(result);
                }

            }
            return Task.CompletedTask;
        }
    }
}
