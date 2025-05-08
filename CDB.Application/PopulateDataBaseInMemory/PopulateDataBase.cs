using CDB.Application.Commands.MesesImposto;
using CDB.Application.Commands.TbCdi;
using CDB.Application.Queries.TbCdi;
using MediatR;

namespace CDB.Application.PopulateDataBaseInMemory;

public static class PopulateDataBase
{
    public async static Task PopulateDatabaseInMemory(IMediator mediator)
    {
        var countTbCdi = await mediator.Send(new TbCdiQuery());
        
        if (countTbCdi == null)
        {
            await mediator.Send(new CreateTbCdiCommand() { Tb = 1.08M, Cdi = 0.009M });

            await mediator.Send(new CreateMesesImpostoCommand() { QtdMeses = 6, PorcentagemImposto = 0.225M });
            await mediator.Send(new CreateMesesImpostoCommand() { QtdMeses = 12, PorcentagemImposto = 0.2M });
            await mediator.Send(new CreateMesesImpostoCommand() { QtdMeses = 24, PorcentagemImposto = 0.175M });
            await mediator.Send(new CreateMesesImpostoCommand() { QtdMeses = 60, PorcentagemImposto = 0.15M });

        }
    }
}
