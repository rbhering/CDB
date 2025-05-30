using CDB.Application.Dtos;
using CDB.Application.Queries.CdbResponseDto;
using CDB.Application.Validators;
using FluentValidation;
using MediatR;



using Microsoft.AspNetCore.Mvc;

namespace CDB.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CdbController(IMediator mediator, IValidator<CdbRequestDto> validatorCdbRequestDto) : ControllerBase
{

    [HttpPost(Name = "PostCdb")]
    public async Task<IActionResult> Post([FromBody] CdbRequestDto cdbRequestDto)
    {
        var validation = validatorCdbRequestDto.Validate(cdbRequestDto);

        if (validation.IsValid)
        {
            try
            {
                var retorno = await mediator.Send(new CdbRequestDtoQuery(cdbRequestDto));
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro ao processar a solicitação", error = ex.Message });
            }
        }
        else
        {
            return BadRequest(new
            {
                message = "Dados inválidos",
                errors = validation.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage).Values
            });
        }
    }
}




