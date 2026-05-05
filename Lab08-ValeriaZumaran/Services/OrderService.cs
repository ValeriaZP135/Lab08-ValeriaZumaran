using Lab08_ValeriaZumaran.Interfaces;

namespace Lab08_ValeriaZumaran.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<object>> GetPedidosDespuesDeFecha(DateTime fecha)
    {
        return await _orderRepository.GetPedidosDespuesDeFecha(fecha);
    }

    public async Task<object?> GetClienteConMasPedidos()
    {
        return await _orderRepository.GetClienteConMasPedidos();
    }
}