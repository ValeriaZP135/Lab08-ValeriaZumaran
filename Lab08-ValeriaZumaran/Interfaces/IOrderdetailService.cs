namespace Lab08_ValeriaZumaran.Interfaces;

public interface IOrderdetailService
{
    Task<IEnumerable<object>> GetDetalleOrden(int orderId);
    Task<object> GetCantidadTotalPorOrden(int orderId);
    Task<IEnumerable<object>> GetTodosLosPedidosConDetalles();
    Task<IEnumerable<string>> GetProductosPorCliente(int clientId);
}