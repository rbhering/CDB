using CDB.Domain.Entities;

namespace CDB.Domain.Interfaces;

public interface ITbCdiRepository
{
    Task<int> AddTbCdiAsync(TbCdi tbCdi);
    Task<TbCdi?> GetSingleTbCdiAsync();
    Task<bool> GetAny();
}