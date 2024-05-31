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
        [MyLoggingAtribute("MyAttribute")]// First request hits MyLogging then hits MyLoggingAtribute then MyLoggingAtributeAsync then hits the controller
        [MyLoggingAtributeAsync("BothAttribute")]// The order here is important
        public async Task<IActionResult> Delete()
        {

            return Ok();
        }
    }
}
