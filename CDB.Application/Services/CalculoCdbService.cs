using CDB.Application.Dtos;
using CDB.Application.Interfaces;
using CDB.Application.Queries.MesesImposto;
using CDB.Application.Queries.TbCdi;
using CDB.Application.Validators;
using CDB.Domain.Entities;
using MediatR;

namespace CDB.Application.Services;

public class CalculoCdbService(IMediator? mediator) : ICalculoCdbService
{
    public required TbCdi TbCdi { get; set; }
    public required List<MesesImposto> MesesImpostos { get; set; }

    public async Task PopularTbCdiAsync()
    {
        var tbCdiQuery = new TbCdiQuery();
        TbCdi = mediator != null ? await mediator.Send(tbCdiQuery) : TbCdi;
    }
    public async Task PopularMesesImpostoAsync()
    {
        var mesesImpostoQuery = new MesesImpostoQuery();
        MesesImpostos = mediator != null ? await mediator.Send(mesesImpostoQuery) : MesesImpostos;
        
    }

    public async Task<CdbResponseDto> CalcularCdb(CdbRequestDto cdbRequestDto)
    {
        await PopularTbCdiAsync();
        await PopularMesesImpostoAsync();

        var cdbResponseDto = new CdbResponseDto();

        foreach (var item in MesesImpostos.OrderBy(x => x.QtdMeses))
        {
            if (cdbRequestDto.QtdMeses <= item.QtdMeses)
            {
                cdbResponseDto.ValorBruto =  CalcularValorBruto(cdbRequestDto.ValorInicial, cdbRequestDto.QtdMeses, TbCdi);

                decimal imposto = CalcularImposto(cdbResponseDto.ValorBruto, cdbRequestDto.ValorInicial, item.PorcentagemImposto);

                cdbResponseDto.ValorLiquido = Math.Round(CalcularValorLiquido(cdbResponseDto.ValorBruto, imposto), 2);

                cdbResponseDto.ValorBruto = Math.Round(cdbResponseDto.ValorBruto, 2);

                return cdbResponseDto;
            }
        }

        return cdbResponseDto;

    }

    private static decimal CalcularValorBruto(decimal valorInicial, decimal qtdMeses, TbCdi tbCdi)
    {
        return valorInicial * (decimal)Math.Pow((double)(1 + (tbCdi.Cdi * tbCdi.Tb)), (double)qtdMeses);
    }

    private static decimal CalcularImposto(decimal valorFinal, decimal valorInicial, decimal porcentagemImposto)
    {
        return (valorFinal - valorInicial) * porcentagemImposto;
    }
    private static decimal CalcularValorLiquido(decimal valorFinal, decimal imposto)
    {
        return valorFinal - imposto;
    }
}
