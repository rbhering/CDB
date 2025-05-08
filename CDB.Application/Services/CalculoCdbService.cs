using CDB.Application.Dtos;
using CDB.Application.Interfaces;
using CDB.Application.PopulateDataBaseInMemory;
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

    public async Task PopulateTbCdiAsync()
    {
        var tbCdiQuery = new TbCdiQuery();
        TbCdi = mediator != null ? await mediator.Send(tbCdiQuery) : TbCdi;
    }
    public async Task PopulateMesesImpostoAsync()
    {
        var mesesImpostoQuery = new MesesImpostoQuery();
        MesesImpostos = mediator != null ? await mediator.Send(mesesImpostoQuery) : MesesImpostos;
        
    }

    public CdbResponseDto CalcularCdb(CdbRequestDto cdbRequestDto)
    {
        CdbRequestDtoValidacao.CdbRequestDtoValidar(cdbRequestDto);
        CdbRequestDtoValidacao.MesesImpostooValidar(MesesImpostos);
        CdbRequestDtoValidacao.TbCdiValidar(TbCdi);


        var cdbResponseDto = new CdbResponseDto();

        foreach (var item in MesesImpostos.OrderBy(x => x.QtdMeses))
        {
            if (cdbRequestDto.QtdMeses <= item.QtdMeses)
            {
                cdbResponseDto.ValorBruto =
                    Math.Round(CalcularValorBruto(cdbRequestDto.ValorInicial, item.QtdMeses, TbCdi), 2);

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
