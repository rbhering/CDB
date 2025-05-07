using CDB.Application.Dtos;

namespace CDB.Application.Interfaces;

public interface ICalculoCdbService
{
    Task<CdbResponseDto> CalcularCdb(CdbRequestDto cdbRequestDto);
}
