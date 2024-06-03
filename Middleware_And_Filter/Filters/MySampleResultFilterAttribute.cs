using Microsoft.AspNetCore.Mvc.Filters;

namespace Middleware_And_Filter.Filters
{
    // This class is used when we have parameters to pass to
    public class MySampleResultFilterAttribute : Attribute, IResultFilter
    {
        private readonly ILogger<MySampleResultFilterAttribute> _logger;
        private Guid _randomId;
        private readonly string _name;

        public MySampleResultFilterAttribute(ILogger<MySampleResultFilterAttribute> logger, string name = "Global")
        {
            _logger = logger;
            _randomId = Guid.NewGuid();
            _name = name;
        }
        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation($"Result Filter Befor - {_name} - {_randomId}");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation($"Result Filter After - {_name} - {_randomId}");
        }
    }


    // // We can use this one(down one) when we donot have any parameter to pass on
    // // if we use this one(down one) we should use [ServiceFilter(typeof(MySampleResultFilterAttribute))] in controller 
    // // but if want to pass parameter we can use above class and use [TypeFilter(typeof(MySampleResultFilterAttribute), Arguments = new object[]{"your parrameter"})] in controller.





    //public class MySampleResultFilterAttribute : Attribute, IResultFilter
    //{
    //    private readonly ILogger<MySampleResultFilterAttribute> _logger;
    //    private Guid _randomId;

    //    public MySampleResultFilterAttribute(ILogger<MySampleResultFilterAttribute> logger)
    //    {
    //        _logger = logger;
    //        _randomId = Guid.NewGuid();
    //    }
    //    public void OnResultExecuting(ResultExecutingContext context)
    //    {
    //        _logger.LogInformation($"Result Filter Befor - {_randomId}");
    //    }

    //    public void OnResultExecuted(ResultExecutedContext context)
    //    {
    //        _logger.LogInformation($"Result Filter After - {_randomId}");
    //    }
    //}
}
