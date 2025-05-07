namespace CDB.Domain.Entities;

public class MesesImposto
{
    public int MesesImpostoId { get; set; }
    public required int QtdMeses { get; set; }
    public required decimal PorcentagemImposto { get; set; }
}
