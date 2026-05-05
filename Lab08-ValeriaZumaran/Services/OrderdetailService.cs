using Lab08_ValeriaZumaran.Interfaces;

namespace Lab08_ValeriaZumaran.Services;

public class OrderdetailService : IOrderdetailService
{
    private readonly IOrderdetailRepository _orderDetailRepository;

    public OrderdetailService(IOrderdetailRepository orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task<IEnumerable<object>> GetDetalleOrden(int orderId)
    {
        return await _orderDetailRepository.GetDetalleOrden(orderId);
    }

    public async Task<object> GetCantidadTotalPorOrden(int orderId)
    {
        return await _orderDetailRepository.GetCantidadTotalPorOrden(orderId);
    }

    public async Task<IEnumerable<object>> GetTodosLosPedidosConDetalles()
    {
        return await _orderDetailRepository.GetTodosLosPedidosConDetalles();
    }

    public async Task<IEnumerable<string>> GetProductosPorCliente(int clientId)
    {
        return await _orderDetailRepository.GetProductosPorCliente(clientId);
    }
}