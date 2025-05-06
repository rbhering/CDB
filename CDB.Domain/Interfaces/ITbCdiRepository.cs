using CDB.Domain.Entities;

namespace CDB.Domain.Interfaces;

public interface ITbCdiRepository
{
    Task<TbCdi> GetTbCdiAsync();
    Task<bool> AddTbCdiAsync(TbCdi tbCdi);
}