using CDB.Application.Dtos;
using FluentValidation;

namespace CDB.Application.Validators;

public class CdbRequestDtoValidator : AbstractValidator<CdbRequestDto>
{
    public CdbRequestDtoValidator()
    {
        RuleFor(x => x.QtdMeses)
            .InclusiveBetween(2, 60)
            .WithMessage("O campo Quantidade de Meses deve estar entre 2 e 60 meses.");

        RuleFor(x => x.ValorInicial)
            .InclusiveBetween(0.01M, 250000)
            .WithMessage("O campo Valor Inicial  deve estar entre 0,01 e 250.000,00.");
    }
}
