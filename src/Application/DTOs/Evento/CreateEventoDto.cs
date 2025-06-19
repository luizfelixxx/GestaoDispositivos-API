using Domain.Enums;

namespace Application.DTOs.Evento;

public record CreateEventoDto(Guid DispositivoId, TipoEvento Tipo, DateTime DataHora);