using Application.DTOs.Dispositivo;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Dispositivos;

public class CreateDispositivoUseCase
{
    private readonly IDispositivoRepository _dispositivoRepository;
    private readonly IClienteRepository _clienteRepository;

    public CreateDispositivoUseCase(IDispositivoRepository dispositivoRepository, IClienteRepository clienteRepository)
    {
        _dispositivoRepository = dispositivoRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task<Dispositivo?> ExecuteAsync(Guid clienteId, CreateDispositivoDto dto)
    {
        var cliente = await _clienteRepository.GetByIdAsync(clienteId);
        if (cliente == null || !cliente.Status)
        {
            // Regra: Não se pode adicionar dispositivo a cliente inexistente ou inativo
            return null;
        }

        var dispositivo = new Dispositivo(dto.Serial, dto.IMEI, clienteId);
        await _dispositivoRepository.AddAsync(dispositivo);
        await _dispositivoRepository.SaveChangesAsync();
        return dispositivo;
    }
}