using Microsoft.EntityFrameworkCore;
using connectWeek.Domain.Entities;
using connectWeek.Domain.Interfaces;
using connectWeek.Infra.Data;

namespace connectWeek.Infra.Repositories;

public class DesafioRepository : IDesafioRepository
{
    private readonly AppDbContext _dbContext;

    public DesafioRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Desafio?> ObterPorIdAsync(Guid id)
    {
        return await _dbContext.Desafios
            .Include(d => d.Usuario)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<IEnumerable<Desafio>> ObterTodosAsync()
    {
        return await _dbContext.Desafios
            .Include(d => d.Usuario)
            .ToListAsync();
    }

    public async Task AdicionarAsync(Desafio desafio)
    {
        await _dbContext.Desafios.AddAsync(desafio);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Desafio desafio)
    {
        _dbContext.Desafios.Update(desafio);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoverAsync(Guid id)
    {
        var desafio = await ObterPorIdAsync(id);
        if (desafio != null)
        {
            _dbContext.Desafios.Remove(desafio);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task SalvarAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Desafio>> ObterPorEventoAsync(Guid idEvento)
    {
        return await _dbContext.Desafios
            .Where(d => d.Eventos!.Any(e => e.EventoId == idEvento))
            .ToListAsync();
    }

}
