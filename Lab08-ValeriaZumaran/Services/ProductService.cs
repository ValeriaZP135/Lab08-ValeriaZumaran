using Lab08_ValeriaZumaran.Interfaces;

namespace Lab08_ValeriaZumaran.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<object>> GetProductosPorPrecio(decimal precio)
    {
        return await _productRepository.GetProductosPorPrecio(precio);
    }

    public async Task<object?> GetProductoMasCaro()
    {
        return await _productRepository.GetProductoMasCaro();
    }

    public async Task<object> GetPromedioPrecio()
    {
        return await _productRepository.GetPromedioPrecio();
    }

    public async Task<IEnumerable<object>> GetProductosSinDescripcion()
    {
        return await _productRepository.GetProductosSinDescripcion();
    }
}