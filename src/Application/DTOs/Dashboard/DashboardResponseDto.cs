namespace Application.DTOs.Dashboard;

public record DashboardResponseDto(Dictionary<string, int> ContagemEventosUltimos7Dias);