using Microsoft.AspNetCore.Mvc.Filters;

namespace Middleware_And_Filter.Filters
{
    public class MyLoggingFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine(("This Filter Executed Befor"));
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine(("This Filter Executed After"));
        }
    }
}
