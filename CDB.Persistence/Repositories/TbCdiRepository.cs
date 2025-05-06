using CDB.Domain.Entities;
using CDB.Domain.Interfaces;

namespace CDB.Persistence.Repositories;

public class TbCdiRepository : ITbCdiRepository
{
    public async Task<bool> AddTbCdiAsync(TbCdi tbCdi)
    {
        throw new NotImplementedException();
    }

    public async Task<TbCdi> GetTbCdiAsync()
    {
        var tbCdiFake = new TbCdi()
        {
            Tb = 1.08M,
            Cdi = 0.009M
        };

        return await Task.FromResult(tbCdiFake);
    }
}
