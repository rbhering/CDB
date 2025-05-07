using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using CDB.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CDB.Persistence.Repositories;

public class TbCdiRepository : ITbCdiRepository
{
    private readonly CdbContext _context;

    public TbCdiRepository(CdbContext context)
    {
        _context = context;
    }

    public async Task<int> AddTbCdiAsync(TbCdi tbCdi)
    {
        _context.Add(tbCdi);
        return await _context.SaveChangesAsync();
    }

    public async Task<TbCdi?> GetSingleTbCdiAsync()
    {
        if (await GetAny())
            return await _context.TbCdi.FirstOrDefaultAsync();

        return null;
    }

    public async Task<bool> GetAny()
    {
        return await _context.TbCdi.AnyAsync();

    }
}
