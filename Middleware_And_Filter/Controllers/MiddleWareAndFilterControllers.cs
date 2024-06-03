// LEarned from https://www.youtube.com/watch?v=kqwjrJ4kb9Q
using Microsoft.AspNetCore.Mvc;
using Middleware_And_Filter.Filters;

namespace Middleware_And_Filter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MiddleWareAndFilterControllers : ControllerBase
    {

        [HttpGet]
        //[MySampleResourceFilter("Action")]
        public async Task<IActionResult> Get() // MyLogging Middleware will run befor and after hitting the controller
        {

             
            return Ok("true");
        }



        [HttpPost]
        [MyLoggingAtribute("MyAttribute")]// First request hits MyLogging then hits MyLoggingAtribute then hits the controller
        public async Task<IActionResult> Post()
        {


            return Ok();
        }

        [HttpPut]
        [MyLoggingAtributeAsync("MyAsyncAttribute")]// First request hits MyLogging then hits MyLoggingAtributeAsync then hits the controller
        public async Task<IActionResult> Put()
        {

            return Ok();
        }

        [HttpDelete]
        // Adding  filter attribute at the method level here
        [MyLoggingAtribute("MyAttribute")]// First request hits MyLogging then hits MyLoggingAtribute then MyLoggingAtributeAsync then hits the controller
        [MyLoggingAtributeAsync("BothAttribute")]// The order here is important
        // in case you have another call of this method in global level, it will call 2 times. one in global level and one in method level.
        [ServiceFilter(typeof(MySampleResultFilterAttribute))]  // we can not call MySampleClassAttribute like other here because it has dependency injection inside of class. this class called 2 time as we used it one in program.cs and one here.
        // so we use serviceFilter type here to be able to use dependency injection. it is exactly like opt.Filters.AddService<MySampleResultFilterAttribute>(); in program.cs . They do the same job in different places.
        // Here we dont have any parameter to pass 
        public async Task<IActionResult> Delete()
        {

            return Ok();
        }

        [HttpDelete("Delete 2")]
        // In this 
        [TypeFilter(typeof(MySampleResultFilterAttribute), Arguments = new object[]{"Action"})]// The TypeFilterAttribute is very similar to service filter attribute but in this case the attribute class it self is not resolved from Di
        // if we want to pass any parameters to the class like name, you can use TypeFilter(...) here. as you can see we passed the Action name to this class so we know that we called this class from here and we can do sifferent functionality when it called from here.
        // this is same as       [ServiceFilter(typeof(MySampleResultFilterAttribute))]    from above but with this different that you can pass parametters to this class.
        // another different is that as we used (TypeFilter), it is not singleton and with each call, it create a new class and create a new guid in this case. but the global is single tone and just the action one(this one is not singleton).
        public async Task<IActionResult> Delete2()
        {

            return Ok();
        }
    }
}
