using Microsoft.EntityFrameworkCore;
using TVSeriesWebAPIw5Challenge.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TVSeriesContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("TVSeriesDB"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("TVSeriesDB"))
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
