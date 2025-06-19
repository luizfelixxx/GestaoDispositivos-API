using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Clientes;

public class GetClienteByIdUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public GetClienteByIdUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente?> ExecuteAsync(Guid id)
    {
        return await _clienteRepository.GetByIdAsync(id);
    }
}