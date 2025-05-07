using MediatR;

namespace CDB.Application.Commands.TbCdi;

public class CreateTbCdiCommand : IRequest<int>
{
    public required decimal Tb { get; set; }
    public required decimal Cdi { get; set; }
}
