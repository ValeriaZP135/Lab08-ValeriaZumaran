using Lab08_ValeriaZumaran.Interfaces;
using Lab08_ValeriaZumaran.Models;

namespace Lab08_ValeriaZumaran.Repositories;

using Microsoft.EntityFrameworkCore;

public class OrderdetailRepository : Repository<Orderdetail>, IOrderdetailRepository
{
    private readonly Lab8DbContext _context;

    public OrderdetailRepository(Lab8DbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> GetDetalleOrden(int orderId) =>
        await _context.Orderdetails
            .Where(d => d.Orderid == orderId)
            .Select(d => new { ProductName = d.Product.Name, d.Quantity } as object)
            .ToListAsync();

    public async Task<object> GetCantidadTotalPorOrden(int orderId)
    {
        var total = await _context.Orderdetails
            .Where(d => d.Orderid == orderId)
            .SumAsync(d => d.Quantity);
        return new { OrderId = orderId, TotalQuantity = total };
    }

    public async Task<IEnumerable<object>> GetTodosLosPedidosConDetalles() =>
        await _context.Orderdetails
            .Select(d => new { d.Orderid, ProductName = d.Product.Name, d.Quantity } as object)
            .ToListAsync();

    public async Task<IEnumerable<string>> GetProductosPorCliente(int clientId) =>
        await _context.Orderdetails
            .Where(d => d.Order.Clientid == clientId)
            .Select(d => d.Product.Name)
            .Distinct()
            .ToListAsync();
}