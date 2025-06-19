using Domain.Entities;
using Domain.Enums;

namespace Domain.Interfaces;

public interface IEventoRepository
{
    Task AddAsync(Evento evento);
    Task<IEnumerable<Evento>> GetEventosAsync(DateTime? startDate, DateTime? endDate, Guid? dispositivoId);
    Task<Dictionary<TipoEvento, int>> GetEventosCountLast7DaysAsync();
    Task<bool> DispositivoExistsAsync(Guid dispositivoId);
    Task<bool> SaveChangesAsync();
}