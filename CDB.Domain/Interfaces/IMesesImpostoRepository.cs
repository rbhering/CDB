using CDB.Domain.Entities;

namespace CDB.Domain.Interfaces;

public interface IMesesImpostoRepository
{
    Task<List<MesesImposto>> GetAllMesesImpostoAsync();
    Task<int> AddMesImpostoAsync(MesesImposto mesesImposto);
}
