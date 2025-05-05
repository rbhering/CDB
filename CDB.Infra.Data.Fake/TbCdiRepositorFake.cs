using CDB.Domain.Entidades;
using CDB.Domain.Interfaces.Repositories;

namespace CDB.Infra.Data.Fake;

public class TbCdiRepositorFake : ITbCdiRepository
{
    public async Task<TbCdi> GetTbCdiAsync()
    {
        var tbCdiFake = new TbCdi() 
        {
            Tb = 1.08M,
            Cdi= 0.009M
        };

        return await Task.FromResult(tbCdiFake);
    }   
}
