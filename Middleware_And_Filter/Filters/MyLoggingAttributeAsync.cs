using Microsoft.AspNetCore.Mvc.Filters;

namespace Middleware_And_Filter.Filters
{
    public class MyLoggingAtributeAsync : Attribute, IAsyncActionFilter
    {
        private readonly string _callername;

        public MyLoggingAtributeAsync(string callername)
        {
            _callername = callername;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"This Filter async Executed Befor {_callername}");
            await next();
            Console.WriteLine($"This Filter async Executed After{_callername}");

        }
    }
}
