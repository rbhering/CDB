using MediatR;

namespace CDB.Application.Commands.TbCdi;

public class CreateMesesImpostoCommand : IRequest<int>
{
    public required int QtdMeses { get; set; }
    public required decimal PorcentagemImposto { get; set; }
}
