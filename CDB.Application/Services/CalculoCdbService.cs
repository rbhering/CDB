using CDB.Application.Interfaces;
using CDB.Application.Dtos;
using CDB.Domain.Entidades;
using CDB.Domain.Interfaces.Repositories;
using CDB.Application.Validators;

namespace CDB.Application.Services;

public class CalculoCdbService : ICalculoCdbService
{
    private readonly IMesesImpostoRepository _mesesImpostoRepository;
    private readonly ITbCdiRepository _tbCdiRepository;

    public CalculoCdbService(IMesesImpostoRepository mesesImpostoRepository, ITbCdiRepository tbCdiRepository)
    {
        _mesesImpostoRepository = mesesImpostoRepository;
        _tbCdiRepository = tbCdiRepository;
    }

    public async Task<CdbResponseDto> CalcularCdb(CdbRequestDto cdbRequestDto)
    {
        CdbRequestDtoValidacao.CdbRequestDtoValidar(cdbRequestDto);

        var mesesImposto = await _mesesImpostoRepository.GetMesesImpostoAsync();
        var tbCdi = await _tbCdiRepository.GetTbCdiAsync();
        var cdbResponseDto = new CdbResponseDto();

        foreach (var item in mesesImposto.OrderBy(x => x.QtdMeses))
        {
            if (cdbRequestDto.QtdMeses <= item.QtdMeses)
            {
                var valorFinal = CalcularValorFinal(cdbRequestDto.ValorInicial, item.QtdMeses, tbCdi);

                cdbResponseDto.ValorBruto = Math.Round(CalcularValorBruto(valorFinal, cdbRequestDto.ValorInicial), 2);

                cdbResponseDto.ValorLiquido = Math.Round(CalcularValorLiquido(cdbResponseDto.ValorBruto, item.PorcentagemImposto), 2);

                return cdbResponseDto;
            }
        }

        return cdbResponseDto;

    }

    private static decimal CalcularValorFinal(decimal valorInicial, decimal qtdMeses, TbCdi tbCdi)
    {
        return valorInicial * (decimal)Math.Pow((double)(1 + (tbCdi.Cdi * tbCdi.Tb)), (double)qtdMeses);
    }
    private static decimal CalcularValorBruto(decimal valorFinal, decimal valorInicial)
    {
        return valorFinal - valorInicial;
    }

    private static decimal CalcularValorLiquido(decimal valorBruto, decimal porcentagemImposto)
    {
        return valorBruto - (valorBruto * porcentagemImposto);
    }
}
