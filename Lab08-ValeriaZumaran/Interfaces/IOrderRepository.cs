using Lab08_ValeriaZumaran.Models;

namespace Lab08_ValeriaZumaran.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<object>> GetPedidosDespuesDeFecha(DateTime fecha);
    Task<object?> GetClienteConMasPedidos();
}