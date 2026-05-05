using Lab08_ValeriaZumaran.Models;

namespace Lab08_ValeriaZumaran.Interfaces;

public interface IOrderdetailRepository : IRepository<Orderdetail>
{
    Task<IEnumerable<object>> GetDetalleOrden(int orderId);
    Task<object> GetCantidadTotalPorOrden(int orderId);
    Task<IEnumerable<object>> GetTodosLosPedidosConDetalles();
    Task<IEnumerable<string>> GetProductosPorCliente(int clientId);
}