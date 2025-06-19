using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Dispositivos;

public class GetDispositivosByClienteUseCase
{
    private readonly IDispositivoRepository _dispositivoRepository;

    public GetDispositivosByClienteUseCase(IDispositivoRepository dispositivoRepository)
    {
        _dispositivoRepository = dispositivoRepository;
    }

    public async Task<IEnumerable<Dispositivo>> ExecuteAsync(Guid clienteId)
    {
        return await _dispositivoRepository.GetByClienteIdAsync(clienteId);
    }
}