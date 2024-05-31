using Middleware_And_Filter.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new MyLoggingFilter());// This is a filter which Runs befor and after any request to controllers
    opt.Filters.Add(new MyLoggingFilter2());// You can add as many as filters you like to your controllers, (the order is important) . You can add order here as well.




    opt.Filters.Add(new MySampleResourceFilterAttribute("Global"));// Ass in Filters First filter is authorization and secnd one is Resource filter. we dont have Authorization so it runs first of all.
    opt.Filters.Add(new MySampleActionFilterAttribute("Action"));
    opt.Filters.Add(new MySampleExceptionFilterAttribute("Exception"));

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
