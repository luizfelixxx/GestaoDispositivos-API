using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Eventos;

public class GetEventosUseCase
{
    private readonly IEventoRepository _eventoRepository;

    public GetEventosUseCase(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    public async Task<IEnumerable<Evento>> ExecuteAsync(DateTime? startDate, DateTime? endDate, Guid? dispositivoId)
    {
        return await _eventoRepository.GetEventosAsync(startDate, endDate, dispositivoId);
    }
} 