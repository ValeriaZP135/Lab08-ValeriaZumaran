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

// FORZAR SELECCIÓN DE BASE DE DATOS (RENDER vs LOCAL)
// 1. Buscamos primero si Render nos inyectó la variable ConnectionStrings__DefaultConnection
var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

// 2. Si no existe en el sistema (porque estás en local), lee tu appsettings.json con localhost
if (string.IsNullOrEmpty(connectionString))
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}

// 3. Pasamos la conexión final ganadora a PostgreSQL con la convención de minúsculas
builder.Services.AddDbContext<Lab8DbContext>(options =>
    options.UseNpgsql(connectionString)
        .UseSnakeCaseNamingConvention());


var app = builder.Build();

app.UseHttpsRedirection();

// HABILITAR SWAGGER Y OPENAPI EN PRODUCCIÓN (FUERA DE CONDICIONALES)
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab08 API v1");
    c.RoutePrefix = string.Empty; // Swagger será la pantalla principal en Render
});

app.UseAuthorization();
app.MapControllers();

app.Run();
