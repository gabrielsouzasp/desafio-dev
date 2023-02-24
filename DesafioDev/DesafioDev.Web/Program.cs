using DesafioDev.Web.Interfaces.Repositories;
using DesafioDev.Web.Interfaces.Services;
using DesafioDev.Web.Repositories;
using DesafioDev.Web.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Desafio Dev",
        Version = "v1.0.0"
    });

    s.EnableAnnotations();
    s.CustomSchemaIds(x => x.FullName);
});

builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

var app = builder.Build();

app.MapControllers();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
