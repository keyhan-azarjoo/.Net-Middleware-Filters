using Microsoft.AspNetCore.Mvc.Filters;

namespace Middleware_And_Filter.Filters
{
    public class MyLoggingFilter2 : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine(("This Filter 2 Executed Befor"));
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine(("This Filter 2 Executed After"));
        }
    }
}
