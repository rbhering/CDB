using CDB.Domain.Entities;
using CDB.Domain.Interfaces;

namespace CDB.Persistence.Repositories;

public class MesesImpostoRepository : IMesesImpostoRepository
{
    public async Task<bool> AddMesesImpostoAsync(MesesImposto mesesImposto)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<MesesImposto>> GetMesesImpostoAsync()
    {
        List<MesesImposto> listMesesImpostoFake = new List<MesesImposto>();
        {
            listMesesImpostoFake.Add(new MesesImposto { QtdMeses = 6, PorcentagemImposto = 0.225M });
            listMesesImpostoFake.Add(new MesesImposto { QtdMeses = 12, PorcentagemImposto = 0.2M });
            listMesesImpostoFake.Add(new MesesImposto { QtdMeses = 24, PorcentagemImposto = 0.175M });
            listMesesImpostoFake.Add(new MesesImposto { QtdMeses = 60, PorcentagemImposto = 0.15M });
        };
        return await Task.FromResult(listMesesImpostoFake);
    }
}