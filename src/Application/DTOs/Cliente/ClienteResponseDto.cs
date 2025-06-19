namespace Application.DTOs.Cliente;

public record ClienteResponseDto(Guid Id, string Nome, string Email, string? Telefone, bool Status);