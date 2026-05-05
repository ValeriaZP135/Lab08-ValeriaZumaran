using Lab08_ValeriaZumaran.Models;

namespace Lab08_ValeriaZumaran.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<object>> GetProductosPorPrecio(decimal precio);
    Task<object?> GetProductoMasCaro();
    Task<object> GetPromedioPrecio();
    Task<IEnumerable<object>> GetProductosSinDescripcion();
}