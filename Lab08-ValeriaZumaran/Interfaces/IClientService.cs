namespace Lab08_ValeriaZumaran.Interfaces;

public interface IClientService
{
    Task<IEnumerable<object>> GetClientesPorNombre(string nombre);
    Task<IEnumerable<string>> GetClientesPorProducto(int productId);
}