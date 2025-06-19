using Domain.Interfaces;

namespace Application.UseCases.Dashboard;

public class GetDashboardUseCase
{
    private readonly IEventoRepository _eventoRepository;

    public GetDashboardUseCase(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    public async Task<Dictionary<string, int>> ExecuteAsync()
    {
        var contagem = await _eventoRepository.GetEventosCountLast7DaysAsync();
        
        // Converte o dicionário de Enum para um de string para melhor serialização JSON
        return contagem.ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value);
    }
}