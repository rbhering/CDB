using CDB.Domain.Interfaces;
using MediatR;

namespace CDB.Application.Commands.TbCdi;

public class CreateTbCdiCommandHandler(ITbCdiRepository tTbCdiRepository) : IRequestHandler<CreateTbCdiCommand, int>
{
    public Task<int> Handle(CreateTbCdiCommand request, CancellationToken cancellationToken)
    {
        var item = new Domain.Entities.TbCdi() { Tb = request.Tb, Cdi = request.Cdi };

        return tTbCdiRepository.AddTbCdiAsync(item);
    }
}
