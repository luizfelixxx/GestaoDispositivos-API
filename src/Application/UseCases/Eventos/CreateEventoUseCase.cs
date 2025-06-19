using Application.DTOs.Evento;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases.Eventos;

public class CreateEventoUseCase
{
    private readonly IEventoRepository _eventoRepository;

    public CreateEventoUseCase(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    public async Task<Evento?> ExecuteAsync(CreateEventoDto dto)
    {
        var dispositivoExiste = await _eventoRepository.DispositivoExistsAsync(dto.DispositivoId);
        if (!dispositivoExiste)
        {
            // Regra: Não se pode registrar evento para dispositivo que não existe
            return null;
        }

        var evento = new Evento(dto.Tipo, dto.DataHora, dto.DispositivoId);
        await _eventoRepository.AddAsync(evento);
        await _eventoRepository.SaveChangesAsync();
        return evento;
    }
}