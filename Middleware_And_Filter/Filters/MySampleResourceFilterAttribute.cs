using Microsoft.AspNetCore.Mvc;
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

            // If you want to return the value you can do in any were like here.
            // as this is the first class and you have the result in your cache you can return it here at the first level.
            // To do that, you can write your result in your result content.

            context.Result = new ContentResult()
            {
                Content = "This is my result and the request is npot going further."
            };


        }
         
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"This Filter Executed After {_callername}");
        }


    }
}
