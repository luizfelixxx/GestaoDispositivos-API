using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;


public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Cliente?> GetByIdAsync(Guid id)
    {
        return await _context.Clientes
            .Include(c => c.Dispositivos)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
            .AsNoTracking() // Melhora a performance para operações de apenas leitura.
            .ToListAsync();
    }
    
    public async Task<Cliente?> GetByEmailAsync(string email)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(c => c.Email == email);
    }
    
    public async Task AddAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
    }
    
    public void Update(Cliente cliente)
    {
        _context.Entry(cliente).State = EntityState.Modified;
    }
    
    public void Remove(Cliente cliente)
    {
        _context.Clientes.Remove(cliente);
    }
    
    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
