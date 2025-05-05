using CDB.Domain.Entidades;

namespace CDB.Domain.Interfaces.Repositories;

public interface IMesesImpostoRepository
{
    Task<IEnumerable<MesesImposto>> GetMesesImpostoAsync();
}
