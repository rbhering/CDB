using CDB.Domain.Entidades;

namespace CDB.Domain.Interfaces.Repositories;

public interface ITbCdiRepository
{
    Task<TbCdi> GetTbCdiAsync();
}