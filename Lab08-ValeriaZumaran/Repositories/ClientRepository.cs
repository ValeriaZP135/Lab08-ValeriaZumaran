using Lab08_ValeriaZumaran.Interfaces;
using Lab08_ValeriaZumaran.Models;

namespace Lab08_ValeriaZumaran.Repositories;

using Microsoft.EntityFrameworkCore;

public class ClientRepository : Repository<Client>, IClientRepository
{
    private readonly Lab8DbContext _context;

    public ClientRepository(Lab8DbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Client>> GetClientesPorNombre(string nombre) =>
        await _context.Clients
            .Where(c => c.Name.Contains(nombre))
            .ToListAsync();

    public async Task<IEnumerable<string>> GetClientesPorProducto(int productId) =>
        await _context.Orderdetails
            .Where(d => d.Productid == productId)
            .Select(d => d.Order.Client.Name)
            .Distinct()
            .ToListAsync();
}