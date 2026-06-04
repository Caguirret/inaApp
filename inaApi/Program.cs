using inaApp.Common.@interface;
using inaApp.Common.Interfaces;
using inaApp.Services;
using inaApp.Repository;
using inaApp.Common.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Inyeccion de dependencias 
builder.Services.AddScoped<IProductoService, ProductoServices>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();


builder.Services.AddOpenApi();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
