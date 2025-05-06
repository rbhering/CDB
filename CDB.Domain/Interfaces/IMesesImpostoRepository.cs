using CDB.Domain.Entidades;

namespace CDB.Domain.Interfaces;

public interface IMesesImpostoRepository
{
    Task<IEnumerable<MesesImposto>> GetMesesImpostoAsync();
}
