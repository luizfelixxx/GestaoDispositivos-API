namespace Application.DTOs.Dispositivo;

public record DispositivoResponseDto(Guid Id, string Serial, string IMEI, DateTime? DataAtivacao, Guid ClienteId);