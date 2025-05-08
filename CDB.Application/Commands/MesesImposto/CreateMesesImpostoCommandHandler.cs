using CDB.Domain.Interfaces;
using CDB.Persistence.Repositories;
using MediatR;

namespace CDB.Application.Commands.MesesImposto;

public class CreateMesesImpostoCommandHandler(IMesesImpostoRepository mesesImpostoRepository) 
                                                                : IRequestHandler<CreateMesesImpostoCommand, int>
{
    public Task<int> Handle(CreateMesesImpostoCommand request, CancellationToken cancellationToken)
    {
        var item = new Domain.Entities.MesesImposto() { QtdMeses = request.QtdMeses, PorcentagemImposto = request.PorcentagemImposto };

        return mesesImpostoRepository.AddMesImpostoAsync(item);
    }
}
