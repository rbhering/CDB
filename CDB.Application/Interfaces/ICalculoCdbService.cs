using CDB.Application.Dtos;

namespace CDB.Application.Interfaces;

public interface ICalculoCdbService
{
    CdbResponseDto CalcularCdb(CdbRequestDto cdbRequestDto);
    Task PopulateTbCdiAsync();
    Task PopulateMesesImpostoAsync();
}
