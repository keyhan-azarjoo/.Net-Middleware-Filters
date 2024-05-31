using Microsoft.AspNetCore.Mvc.Filters;

namespace Middleware_And_Filter.Filters
{
    public class MySampleResourceFilterAttribute : Attribute, IResourceFilter
    {
        private readonly string _callername;

        public MySampleResourceFilterAttribute(string callername)
        {
            _callername = callername;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"This Filter Executed Befor {_callername}");
        }
         
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"This Filter Executed After {_callername}");
        }


    }
}
