using CDB.Application.Dtos;

namespace CDB.Application.Validators
{
    internal static class CdbRequestDtoValidacao
    {
        public static bool CdbRequestDtoValidar(CdbRequestDto cdbRequestDto)
        {
            if (cdbRequestDto.ValorInicial <= 0 || cdbRequestDto.ValorInicial > 250000)
                throw new ArgumentException("Valor Inicial deve ser maior que zero e menor ou igual a 250.000,00.");

            if (cdbRequestDto.QtdMeses <= 1 || cdbRequestDto.QtdMeses > 60)
                throw new ArgumentException("Quantidade de meses deve ser maior ou igual a 2 e menor ou igual a 60.");

            return true;
        }
    }
}
