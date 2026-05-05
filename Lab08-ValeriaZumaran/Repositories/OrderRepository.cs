using Lab08_ValeriaZumaran.Interfaces;
using Lab08_ValeriaZumaran.Models;

namespace Lab08_ValeriaZumaran.Repositories;

using Microsoft.EntityFrameworkCore;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private readonly Lab8DbContext _context;

    public OrderRepository(Lab8DbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> GetPedidosDespuesDeFecha(DateTime fecha) =>
        await _context.Orders
            .Where(o => o.Orderdate > fecha)
            .ToListAsync();
    
    public async Task<object?> GetClienteConMasPedidos()
    {
        var ordenes = await _context.Orders.ToListAsync();

        return ordenes
            .GroupBy(o => o.Clientid)
            .OrderByDescending(g => g.Count())
            .Select(g => new { ClientId = g.Key, TotalOrders = g.Count() })
            .FirstOrDefault();
    }
    
    
}