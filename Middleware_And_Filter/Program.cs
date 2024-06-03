using Middleware_And_Filter.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddTransient<MySampleResultFilterAttribute>();   // registering my class to ServiceCollection as a transient type
                                                                    // Whenever the filters requires it, it can resolve it Always (read) from dependancy injection
                                                                    // As we are using Transient, it create a new class of MySampleResultFilterAttribute each time we call a request or this class called.
                                                                    // there is a guid id that shous this matter and by calling any API, a new guid will be generated.
                                                                    // infact by calling any request to any API end point, the whole pipeline will be regenerate.

builder.Services.AddSingleton<MySampleResultFilterAttribute>(); // When we use AddSingleton, it generate this class only one time and in other request, it not create a new class.
                                                                // as we have a guid in this class, when we use Singleton, it not generate new guid for each request and the guidId is same for all requests.




builder.Services.AddControllers(opt =>
{
    // Adding Global filter attribute here


    opt.Filters.Add(new MyLoggingFilter());// This is a filter which Runs befor and after any request to controllers
    opt.Filters.Add(new MyLoggingFilter2());// You can add as many as filters you like to your controllers, (the order is important) . You can add order here as well.




    opt.Filters.Add(new MySampleResourceFilterAttribute("Global"));// As in Filters First filter is authorization and secnd one is Resource filter and we dont have Authorization, it runs first of all.
    opt.Filters.Add(new MySampleActionFilterAttribute("Action"));
    opt.Filters.Add(new MySampleExceptionFilterAttribute("Exception"));
    opt.Filters.AddService<MySampleResultFilterAttribute>();     // regester it as a service filter type. dependency injection service collection. you need to use AddTransient<...> to access dependencies
    //opt.Filters.Add<MySampleResultFilterAttribute>();     // this is same as previous one but with this different that it create a TypeFilter like how it been used in  [HttpDelete("Delete 2")]in controller.


});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
