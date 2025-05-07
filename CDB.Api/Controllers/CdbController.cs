using CDB.Application.Commands.TbCdi;
using CDB.Application.Dtos;
using CDB.Application.PopulateDataBaseInMemory;
using CDB.Application.Queries.CdbResponseDto;
using CDB.Application.Queries.MesesImposto;
using CDB.Application.Queries.TbCdi;
using CDB.Domain.Entities;
using CDB.Persistence.Context;
using MediatR;



using Microsoft.AspNetCore.Mvc;

namespace CDB.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class CdbController(IMediator mediator) : ControllerBase
{

    [HttpPost(Name = "PostCdb")]
    public async Task<IActionResult> Post([FromBody] CdbRequestDto cdbRequestDto )
    {
        if (ModelState.IsValid)
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
                errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
            });
        }
    }
}




