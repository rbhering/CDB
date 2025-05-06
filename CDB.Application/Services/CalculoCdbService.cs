using CDB.Application.Interfaces;
using CDB.Application.Dtos;
using CDB.Domain.Entities;
using CDB.Application.Validators;
using CDB.Domain.Interfaces;

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
                cdbResponseDto.ValorBruto = 
                    Math.Round(CalcularValorBruto(cdbRequestDto.ValorInicial, item.QtdMeses, tbCdi), 2);

                cdbResponseDto.ValorLiquido = 
                    Math.Round(CalcularValorLiquido(cdbRequestDto.ValorInicial, cdbResponseDto.ValorBruto, item.PorcentagemImposto), 2);

                return cdbResponseDto;
            }
        }

        return cdbResponseDto;

    }

    private static decimal CalcularValorBruto(decimal valorInicial, decimal qtdMeses, TbCdi tbCdi)
    {
        return valorInicial * (decimal)Math.Pow((double)(1 + (tbCdi.Cdi * tbCdi.Tb)), (double)qtdMeses);
    }
    private static decimal CalcularValorLiquido(decimal valorInicial, decimal valorBruto, decimal porcentagemImposto)
    {
        return valorInicial + ((valorBruto - valorInicial) * porcentagemImposto);
    }
}
