using EShoppingAPI.Apı.Validation.FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EShoppingAPI.Apı.Aspect
{
    public class ValidationFilter : Attribute, IAsyncActionFilter
    {
        private Type _validatorType;

        public ValidationFilter(Type validatortype)
        {
            _validatorType = validatortype;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ValidationHelper.Validate(_validatorType, context.ActionArguments.Values.ToArray());
            await next();
        }

    }
}
