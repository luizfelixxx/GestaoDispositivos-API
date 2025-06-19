using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Clientes;

public class GetAllClientesUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public GetAllClientesUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<IEnumerable<Cliente>> ExecuteAsync()
    {
        return await _clienteRepository.GetAllAsync();
    }
}