using Microsoft.AspNetCore.Mvc.Filters;

namespace Middleware_And_Filter.Filters
{
    public class MySampleActionFilterAttribute : Attribute, IAsyncActionFilter // , IActionFilter  you can impliment one of them ActionFilter or AsyncActionFilter for other filters as well
    {
        private readonly string _callername;

        public MySampleActionFilterAttribute(string callername)
        {
            _callername = callername;
        }

        //void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        //{
        //    Console.WriteLine($"This Filter Executed Befor {_callername}");
        //}

        //void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        //{
        //    Console.WriteLine($"This Filter Executed After {_callername}");
        //}

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"This Filter Executed Befor {_callername}");
            await next();
            Console.WriteLine($"This Filter Executed After {_callername}");
        }
    }
}
