using Lab08_ValeriaZumaran.Models;

namespace Lab08_ValeriaZumaran.Interfaces;

public interface IClientRepository : IRepository<Client>
{
    Task<List<Client>> GetClientesPorNombre(string nombre);
    Task<IEnumerable<string>> GetClientesPorProducto(int productId);
}