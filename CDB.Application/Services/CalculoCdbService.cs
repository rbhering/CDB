using CDB.Application.Dtos;
using CDB.Application.Interfaces;
using CDB.Application.PopulateDataBaseInMemory;
using CDB.Application.Queries.MesesImposto;
using CDB.Application.Queries.TbCdi;
using CDB.Application.Validators;
using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using MediatR;

namespace CDB.Application.Services;

public class CalculoCdbService : ICalculoCdbService
{
    private readonly IMediator _mediator;

    public CalculoCdbService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<CdbResponseDto> CalcularCdb(CdbRequestDto cdbRequestDto)
    {
        await PopulateDataBase.PopulateDatabaseInMemory(_mediator);

        CdbRequestDtoValidacao.CdbRequestDtoValidar(cdbRequestDto);

        var mesesImposto = await _mediator.Send(new MesesImpostoQuery());        
        var tbCdi = await _mediator.Send(new TbCdiQuery());

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
