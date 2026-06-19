using Lab08_ValeriaZumaran.Interfaces;
using Lab08_ValeriaZumaran.Models;
using Lab08_ValeriaZumaran.Repositories;
using Lab08_ValeriaZumaran.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Repositorios
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderdetailRepository, OrderdetailRepository>();

// Servicios
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderdetailService, OrderdetailService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CONFIGURACIÓN DE BASE DE DATOS CORREGIDA PARA POSTGRES EN RENDER
builder.Services.AddDbContext<Lab8DbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSnakeCaseNamingConvention()); // <-- Traduce automáticamente de Mayúsculas a las minúsculas de Render

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();

app.UseHttpsRedirection();

// HABILITAR SWAGGER TANTO EN LOCAL COMO EN EL DESPLIEGUE DE RENDER
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab08 API v1");
    c.RoutePrefix = string.Empty; // Hace que Swagger sea la página de inicio principal en Render
});

app.UseAuthorization();
app.MapControllers();

app.Run();