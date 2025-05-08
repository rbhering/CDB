using CDB.Application.Dtos;
using CDB.Domain.Entities;

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

        public static bool MesesImpostooValidar(List<MesesImposto> mesesImpostos)
        {
            if (mesesImpostos == null || mesesImpostos.Count == 0)
                throw new ArgumentException("Meses Imposto não pode ser nulo ou vazio.");
            foreach (var item in mesesImpostos)
            {
                if (item.QtdMeses <= 0 || item.PorcentagemImposto < 0)
                    throw new ArgumentException("Quantidade de meses deve ser maior que zero e porcentagem de imposto deve ser maior ou igual a zero.");
            }
            return true;
        }
        public static bool TbCdiValidar(TbCdi tbCdi)
        {
            if (tbCdi == null)
                throw new ArgumentException("TbCdi não pode ser nulo.");
            if (tbCdi.Tb <= 0 || tbCdi.Cdi <= 0)
                throw new ArgumentException("Tb e Cdi devem ser maiores que zero.");
            return true;
        }
    }
}
