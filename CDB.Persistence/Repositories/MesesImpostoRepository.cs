using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using CDB.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CDB.Persistence.Repositories;

public class MesesImpostoRepository : IMesesImpostoRepository
{
    private readonly CdbContext _context;

    public MesesImpostoRepository(CdbContext context)
    {
        _context = context;    
    }

    public async Task<int> AddMesImpostoAsync(MesesImposto mesesImposto)
    {
        _context.Add(mesesImposto);
        return await _context.SaveChangesAsync();
    }

    public async Task<List<MesesImposto>> GetAllMesesImpostoAsync()
    {        
        return await _context.MesesImposto.ToListAsync();
    }
}