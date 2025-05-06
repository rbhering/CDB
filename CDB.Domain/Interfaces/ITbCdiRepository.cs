using CDB.Domain.Entidades;

namespace CDB.Domain.Interfaces;

public interface ITbCdiRepository
{
    Task<TbCdi> GetTbCdiAsync();
}