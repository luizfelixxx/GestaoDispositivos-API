using Domain.Entities;

namespace Domain.Interfaces;

public interface IClienteRepository
{
    Task<Cliente?> GetByIdAsync(Guid id);
    Task<IEnumerable<Cliente>> GetAllAsync();
    Task<Cliente?> GetByEmailAsync(string email);
    Task AddAsync(Cliente cliente);
    void Update(Cliente cliente);
    void Remove(Cliente cliente);
    Task<bool> SaveChangesAsync();
}