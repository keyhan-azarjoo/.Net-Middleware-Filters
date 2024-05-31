using Microsoft.AspNetCore.Mvc.Filters;

namespace Middleware_And_Filter.Filters
{
    public class MySampleExceptionFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _callername;

        public MySampleExceptionFilterAttribute(string callername)
        {
            _callername = callername;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"This Filter Executed On Exception {_callername}");

            await next();
        }
    }
}
