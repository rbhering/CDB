using MediatR;

namespace CDB.Application.Commands.MesesImposto;

public class CreateMesesImpostoCommand : IRequest<int>
{
    public required int QtdMeses { get; set; }
    public required decimal PorcentagemImposto { get; set; }
}
