using CDB.Domain.Entities;

namespace CDB.Domain.Interfaces;

public interface IMesesImpostoRepository
{
    Task<IEnumerable<MesesImposto>> GetMesesImpostoAsync();
    Task<bool> AddMesesImpostoAsync(MesesImposto mesesImposto);
}
