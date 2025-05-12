using CDB.Domain.Entities;

namespace CDB.Common.Tests;

public static class GetPopulateObjects
{
    public static List<MesesImposto> GetMesesImpostoList()
    {
        List<MesesImposto> listMesesImposto = new List<MesesImposto>();
       
        listMesesImposto.Add(new MesesImposto { QtdMeses = 6, PorcentagemImposto = 0.225M });
        listMesesImposto.Add(new MesesImposto { QtdMeses = 12, PorcentagemImposto = 0.2M });
        listMesesImposto.Add(new MesesImposto { QtdMeses = 24, PorcentagemImposto = 0.175M });
        listMesesImposto.Add(new MesesImposto { QtdMeses = 60, PorcentagemImposto = 0.15M });
        
        return listMesesImposto;
    }
    public static TbCdi GetTbCdi()
    {
        return new TbCdi
        {
            Tb = 1.08M,
            Cdi = 0.009M
        };
    }
}
