using WEB_API.Controllers;
using WEB_API.DAL;
using WEB_API.Models;
using WEB_API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers();
builder.Services.AddTransient<ICommonRepository<Customer>, CommonRepository<Customer>>();

builder.Services.AddDbContext<CustumerDbContext>(options =>
{
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
    options.UseMySql("Server=localhost;PORT=3306;Database=Exam;User Id=root;Password=Prasad@0102", serverVersion);
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
