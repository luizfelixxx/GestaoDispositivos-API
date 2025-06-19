using Application.DTOs.Cliente;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Clientes;

public class CreateClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public CreateClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente> ExecuteAsync(CreateClienteDto dto)
    {
        var existingCliente = await _clienteRepository.GetByEmailAsync(dto.Email);
        if (existingCliente != null)
        {
            throw new InvalidOperationException("Já existe um cliente com este e-mail.");
        }

        var cliente = new Cliente(dto.Nome, dto.Email, dto.Telefone);
        await _clienteRepository.AddAsync(cliente);
        await _clienteRepository.SaveChangesAsync();
        return cliente;
    }
}