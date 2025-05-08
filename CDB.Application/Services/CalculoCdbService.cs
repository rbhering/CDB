using AutoMapper;
using CDB.Application.Dtos;
using CDB.Application.Interfaces;
using CDB.Application.PopulateDataBaseInMemory;
using CDB.Application.Queries.MesesImposto;
using CDB.Application.Queries.TbCdi;
using CDB.Application.Validators;
using CDB.Domain.Entities;
using MediatR;

namespace CDB.Application.Services;

public class CalculoCdbService : ICalculoCdbService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CalculoCdbService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<CdbResponseDto> CalcularCdb(CdbRequestDto cdbRequestDto)
    {
        await PopulateDataBase.PopulateDatabaseInMemory(_mediator);

        CdbRequestDtoValidacao.CdbRequestDtoValidar(cdbRequestDto);
 
        cdbRequestDto.MesesImpostosDtos = _mapper.Map<List<MesessImpostoDto>>(await _mediator.Send(new MesesImpostoQuery()));        
        cdbRequestDto.TbCdiDto = _mapper.Map<TbCdiDto>(await _mediator.Send(new TbCdiQuery()));

        var cdbResponseDto = new CdbResponseDto();

        foreach (var item in cdbRequestDto.MesesImpostosDtos.OrderBy(x => x.QtdMeses))
        {
            if (cdbRequestDto.QtdMeses <= item.QtdMeses)
            {
                cdbResponseDto.ValorBruto =
                    Math.Round(CalcularValorBruto(cdbRequestDto.ValorInicial, item.QtdMeses, cdbRequestDto.TbCdiDto), 2);

                cdbResponseDto.ValorLiquido = 
                    Math.Round(CalcularValorLiquido(valorInicial: cdbRequestDto.ValorInicial, cdbResponseDto.ValorBruto, item.PorcentagemImposto), 2);

                return cdbResponseDto;
            }
        }

        return cdbResponseDto;

    }

    private static decimal CalcularValorBruto(decimal valorInicial, decimal qtdMeses, TbCdiDto tbCdi)
    {
        return valorInicial * (decimal)Math.Pow((double)(1 + (tbCdi.Cdi * tbCdi.Tb)), (double)qtdMeses);
    }
    private static decimal CalcularValorLiquido(decimal valorInicial, decimal valorBruto, decimal porcentagemImposto)
    {
        return valorInicial + ((valorBruto - valorInicial) * porcentagemImposto);
    }
}
