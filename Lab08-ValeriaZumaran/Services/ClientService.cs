using Lab08_ValeriaZumaran.Interfaces;

namespace Lab08_ValeriaZumaran.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<IEnumerable<object>> GetClientesPorNombre(string nombre)
    {
        return   await _clientRepository.GetClientesPorNombre(nombre);
    }


    public async Task<IEnumerable<string>> GetClientesPorProducto(int productId)
    {
        return  await _clientRepository.GetClientesPorProducto(productId);
    }
}