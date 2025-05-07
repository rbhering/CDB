using CDB.Application.Dtos;
using CDB.Application.Queries.CdbResponseDto;
using CDB.Application.Queries.MesesImposto;
using CDB.Application.Queries.TbCdi;
using MediatR;


//using CDB.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CDB.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class CdbController(IMediator mediator) : ControllerBase
{
    //private readonly ICalculoCdbService _calculoCdbService;  

    //public CdbController(ICalculoCdbService calculoCdbService)  
    //{        
    //    _calculoCdbService = calculoCdbService;  
    //}  

    [HttpPost(Name = "PostCdb")]
    public async Task<IActionResult> Post([FromBody] CdbRequestDto cdbRequestDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                //var retorno = await mediator.Send(new MesesImpostoQuery());
                var tt = await mediator.Send(new TbCdiQuery());

                var retorno = await mediator.Send(new CdbRequestDtoQuery(cdbRequestDto));

                if (retorno != null)
                    return Ok(retorno);

                return StatusCode(500, new { message = "Ocorreu um erro ao processar a solicitação" });
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




