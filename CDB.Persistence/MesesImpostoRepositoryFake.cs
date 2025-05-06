using CDB.Domain.Entidades;
using CDB.Domain.Interfaces;

namespace CDB.Persistence;

public class MesesImpostoRepositoryFake : IMesesImpostoRepository
{
    public async Task<IEnumerable<MesesImposto>> GetMesesImpostoAsync()
    {
        List<MesesImposto> listMesesImpostoFake = new List<MesesImposto>();
        {
            listMesesImpostoFake.Add(new MesesImposto { QtdMeses = 6, PorcentagemImposto = 0.225M });
            listMesesImpostoFake.Add(new MesesImposto { QtdMeses = 12, PorcentagemImposto = 0.2M });
            listMesesImpostoFake.Add(new MesesImposto { QtdMeses = 24, PorcentagemImposto = 0.175M });
            listMesesImpostoFake.Add(new MesesImposto { QtdMeses = 60, PorcentagemImposto = 0.15M }); //60 é o prazo máximo de meses para Investimento CDB   
        };
        return await Task.FromResult(listMesesImpostoFake);
    }
}