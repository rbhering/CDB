using CDB.Domain.Interfaces;
using MediatR;

namespace CDB.Application.Queries.MesesImposto;

public class MesesImpostoQueryHandler(IMesesImpostoRepository mesesImpostoRepository) 
                            : IRequestHandler<MesesImpostoQuery, List<CDB.Domain.Entities.MesesImposto>>
{
    public async Task<List<CDB.Domain.Entities.MesesImposto>> Handle
                                (MesesImpostoQuery request, CancellationToken cancellationToken)
    {
        return await mesesImpostoRepository.GetAllMesesImpostoAsync();
    }
}
