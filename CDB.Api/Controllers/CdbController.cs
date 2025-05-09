using CDB.Application.Dtos;
using CDB.Application.Queries.CdbResponseDto;
using CDB.Application.Validators;
using MediatR;



using Microsoft.AspNetCore.Mvc;

namespace CDB.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CdbController(IMediator mediator) : ControllerBase
{
    

    [HttpPost(Name = "PostCdb")]
    public async Task<IActionResult> Post([FromBody] CdbRequestDto cdbRequestDto)
    {
        try
        {
            CdbRequestDtoValidacao.CdbRequestDtoValidar(cdbRequestDto);
            var retorno = await mediator.Send(new CdbRequestDtoQuery(cdbRequestDto));
            return Ok(retorno);
        }
        catch (Exception ex)
        {
            if (ex is ArgumentException)
                return BadRequest(new { message = ex.Message });

            return StatusCode(500, new { message = "Ocorreu um erro ao processar a solicitação", error = ex.Message });
        }
    }
}




