using Domain.Entities;

namespace Domain.Interfaces;

public interface IDispositivoRepository
{
    Task<Dispositivo?> GetByIdAsync(Guid id);
    Task<IEnumerable<Dispositivo>> GetByClienteIdAsync(Guid clienteId);
    Task AddAsync(Dispositivo dispositivo);
    void Update(Dispositivo dispositivo);
    void Remove(Dispositivo dispositivo);
    Task<bool> SaveChangesAsync();
}