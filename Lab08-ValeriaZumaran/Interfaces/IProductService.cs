namespace Lab08_ValeriaZumaran.Interfaces;

public interface IProductService
{
    Task<IEnumerable<object>> GetProductosPorPrecio(decimal precio);
    Task<object?> GetProductoMasCaro();
    Task<object> GetPromedioPrecio();
    Task<IEnumerable<object>> GetProductosSinDescripcion();
}