using Application.DTOs.Cliente;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Clientes;

public class UpdateClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public UpdateClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente?> ExecuteAsync(Guid id, UpdateClienteDto dto)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);
        if (cliente == null)
        {
            return null; // Controller tratará como NotFound
        }

        cliente.AtualizarDados(dto.Nome, dto.Telefone);
        _clienteRepository.Update(cliente);
        await _clienteRepository.SaveChangesAsync();
        return cliente;
    }
}