using Lab08_ValeriaZumaran.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_ValeriaZumaran.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LinqController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly IProductService _productService;
    private readonly IOrderService _orderService;
    private readonly IOrderdetailService _orderdetailService;

    public LinqController(
        IClientService clientService,
        IProductService productService,
        IOrderService orderService,
        IOrderdetailService orderetailService)
    {
        _clientService = clientService;
        _productService = productService;
        _orderService = orderService;
        _orderdetailService = orderetailService;
    }

    [HttpGet("ejercicio1")]
    public async Task<IActionResult> GetClientesPorNombre([FromQuery] string nombre = "Juan")
        => Ok(await _clientService.GetClientesPorNombre(nombre));

    [HttpGet("ejercicio2")]
    public async Task<IActionResult> GetProductosPorPrecio([FromQuery] decimal precio = 20)
        => Ok(await _productService.GetProductosPorPrecio(precio));

    [HttpGet("ejercicio3")]
    public async Task<IActionResult> GetDetalleOrden([FromQuery] int orderId = 1)
        => Ok(await _orderdetailService.GetDetalleOrden(orderId));

    [HttpGet("ejercicio4")]
    public async Task<IActionResult> GetCantidadTotalPorOrden([FromQuery] int orderId = 1)
        => Ok(await _orderdetailService.GetCantidadTotalPorOrden(orderId));

    [HttpGet("ejercicio5")]
    public async Task<IActionResult> GetProductoMasCaro()
        => Ok(await _productService.GetProductoMasCaro());

    [HttpGet("ejercicio6")]
    public async Task<IActionResult> GetPedidosDespuesDeFecha([FromQuery] DateTime? fecha = null)
        => Ok(await _orderService.GetPedidosDespuesDeFecha(fecha ?? new DateTime(2025, 5, 1)));

    [HttpGet("ejercicio7")]
    public async Task<IActionResult> GetPromedioPrecio()
        => Ok(await _productService.GetPromedioPrecio());

    [HttpGet("ejercicio8")]
    public async Task<IActionResult> GetProductosSinDescripcion()
        => Ok(await _productService.GetProductosSinDescripcion());

    [HttpGet("ejercicio9")]
    public async Task<IActionResult> GetClienteConMasPedidos()
        => Ok(await _orderService.GetClienteConMasPedidos());

    [HttpGet("ejercicio10")]
    public async Task<IActionResult> GetTodosLosPedidosConDetalles()
        => Ok(await _orderdetailService.GetTodosLosPedidosConDetalles());

    [HttpGet("ejercicio11")]
    public async Task<IActionResult> GetProductosPorCliente([FromQuery] int clientId = 1)
        => Ok(await _orderdetailService.GetProductosPorCliente(clientId));

    [HttpGet("ejercicio12")]
    public async Task<IActionResult> GetClientesPorProducto([FromQuery] int productId = 2)
        => Ok(await _clientService.GetClientesPorProducto(productId));
}