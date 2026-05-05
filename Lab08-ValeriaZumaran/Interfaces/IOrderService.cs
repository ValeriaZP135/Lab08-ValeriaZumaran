namespace Lab08_ValeriaZumaran.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<object>> GetPedidosDespuesDeFecha(DateTime fecha);
    Task<object?> GetClienteConMasPedidos();
}