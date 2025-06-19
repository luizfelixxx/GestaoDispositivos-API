using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly AppDbContext _context;

    public EventoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Evento evento)
    {
        await _context.Eventos.AddAsync(evento);
    }

    public async Task<bool> DispositivoExistsAsync(Guid dispositivoId)
    {
        return await _context.Dispositivos.AnyAsync(d => d.Id == dispositivoId);
    }

    public async Task<IEnumerable<Evento>> GetEventosAsync(DateTime? startDate, DateTime? endDate, Guid? dispositivoId)
    {
        var query = _context.Eventos.AsQueryable();

        if (startDate.HasValue)
        {
            query = query.Where(e => e.DataHora >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            query = query.Where(e => e.DataHora <= endDate.Value);
        }

        if (dispositivoId.HasValue)
        {
            query = query.Where(e => e.DispositivoId == dispositivoId.Value);
        }

        return await query.OrderByDescending(e => e.DataHora).ToListAsync();
    }
    
    public async Task<Dictionary<TipoEvento, int>> GetEventosCountLast7DaysAsync()
    {
        var sevenDaysAgo = DateTime.UtcNow.AddDays(-7);

        return await _context.Eventos
            .Where(e => e.DataHora >= sevenDaysAgo)
            .GroupBy(e => e.Tipo)
            .ToDictionaryAsync(g => g.Key, g => g.Count());
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}