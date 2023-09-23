using Microsoft.EntityFrameworkCore;
using TodoList.Api.Filters;
using TodoList.Application.Extensions;
using TodoList.Application.Tasks;
using TodoList.Domain;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(opt =>
{
    opt.AddPolicy("default", c =>
    {
        c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
builder.Services.AddControllers(options => 
{
    options.Filters.Add<ExceptionFilter>();
});
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddTodoListApplication()
    .AddDbContext<TodoDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default")))
    .AddTransient<ITaskAppService, TaskAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("default");

app.UseAuthorization();

app.MapControllers();

app.Run();
