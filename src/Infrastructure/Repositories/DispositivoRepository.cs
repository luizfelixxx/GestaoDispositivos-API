using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DispositivoRepository : IDispositivoRepository
{
    private readonly AppDbContext _context;

    public DispositivoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Dispositivo?> GetByIdAsync(Guid id)
    {
        return await _context.Dispositivos.FindAsync(id);
    }

    public async Task<IEnumerable<Dispositivo>> GetByClienteIdAsync(Guid clienteId)
    {
        return await _context.Dispositivos
            .Where(d => d.ClienteId == clienteId)
            .ToListAsync();
    }

    public async Task AddAsync(Dispositivo dispositivo)
    {
        await _context.Dispositivos.AddAsync(dispositivo);
    }

    public void Update(Dispositivo dispositivo)
    {
        _context.Dispositivos.Update(dispositivo);
    }

    public void Remove(Dispositivo dispositivo)
    {
        _context.Dispositivos.Remove(dispositivo);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}