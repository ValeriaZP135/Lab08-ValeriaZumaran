using Lab08_ValeriaZumaran.Interfaces;
using Lab08_ValeriaZumaran.Models;

namespace Lab08_ValeriaZumaran.Repositories;

using Microsoft.EntityFrameworkCore;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly Lab8DbContext _context;

    public ProductRepository(Lab8DbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> GetProductosPorPrecio(decimal precio) =>
        await _context.Products
            .Where(p => p.Price > precio)
            .ToListAsync();

    public async Task<object?> GetProductoMasCaro() =>
        await _context.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();

    public async Task<object> GetPromedioPrecio()
    {
        var promedio = await _context.Products
            .AverageAsync(p => p.Price);
        return new { AveragePrice = Math.Round(promedio, 2) };
    }

    public async Task<IEnumerable<object>> GetProductosSinDescripcion() =>
        await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToListAsync();
}