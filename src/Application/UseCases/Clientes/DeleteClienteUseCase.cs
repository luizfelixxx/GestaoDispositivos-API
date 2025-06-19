using Domain.Interfaces;

namespace Application.UseCases.Clientes;

public class DeleteClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public DeleteClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<bool> ExecuteAsync(Guid id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);
        if (cliente == null)
        {
            return false;
        }

        cliente.Desativar(); 
        _clienteRepository.Update(cliente);
        await _clienteRepository.SaveChangesAsync();
        return true;
    }
}