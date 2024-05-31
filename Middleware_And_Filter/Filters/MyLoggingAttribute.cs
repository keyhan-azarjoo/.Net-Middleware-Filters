using Microsoft.AspNetCore.Mvc.Filters;

namespace Middleware_And_Filter.Filters
{
    public class MyLoggingAtribute : Attribute, IActionFilter
    {
        private readonly string _callername;

        public MyLoggingAtribute(string callername)
        {
            _callername = callername;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine(($"This Atribute Filter Executed Befor{_callername}"));
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine(($"This Atribut Filter Executed After{_callername}"));
        }
    }
}
