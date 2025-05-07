using CDB.Application.Dtos;
using CDB.Application.Interfaces;
using CDB.Application.Validators;
using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using MediatR;

namespace CDB.Application.Services;

public class CalculoCdbService : ICalculoCdbService
{
    private readonly IMesesImpostoRepository _mesesImpostoRepository;
    private readonly ITbCdiRepository _tbCdiRepository;
    private readonly IMediator _mediator;

    public CalculoCdbService(IMesesImpostoRepository mesesImpostoRepository, ITbCdiRepository tbCdiRepository, IMediator mediator)
    {
        _mesesImpostoRepository = mesesImpostoRepository;
        _tbCdiRepository = tbCdiRepository;
        _mediator = mediator;
    }

    public async Task<CdbResponseDto> CalcularCdb(CdbRequestDto cdbRequestDto)
    {
        CdbRequestDtoValidacao.CdbRequestDtoValidar(cdbRequestDto);

        var mesesImposto = new List<MesesImposto>();
        mesesImposto.Add(new MesesImposto() { QtdMeses = 11, PorcentagemImposto = 0.2M }); /*(List<MesesImposto>) await _mediator.Send(new MesesImposto() { PorcentagemImposto = 2, QtdMeses = 3 });*/
        var tbCdi = new TbCdi() { Cdi = 0.009M, Tb = 1.08M }; /* (TbCdi) await _mediator.Send(new TbCdi() { Cdi = 2, Tb = 3 });*/
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
