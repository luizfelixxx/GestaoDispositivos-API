using Domain.Enums;

namespace Application.DTOs.Evento;

public record EventoResponseDto(Guid Id, Guid DispositivoId, TipoEvento Tipo, DateTime DataHora);