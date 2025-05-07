using CDB.Domain.Interfaces;
using MediatR;

namespace CDB.Application.Queries.TbCdi;

public class TbCdiQueryHandler(ITbCdiRepository tbCdiRepository)
                       : IRequestHandler<TbCdiQuery, CDB.Domain.Entities.TbCdi?>
{
    public async Task<CDB.Domain.Entities.TbCdi?> Handle
                                (TbCdiQuery request, CancellationToken cancellationToken)
    {
        if (await tbCdiRepository.GetAny())
            return await tbCdiRepository.GetSingleTbCdiAsync();

        return null;
    }
}
