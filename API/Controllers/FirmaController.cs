using Application.Commands;
using Application.Queries;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;
public class FirmaController : ControllerBase
{
    private readonly IMediator _mediator;

    public FirmaController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    [Route("GetFirmaInfo")]
    [ProducesResponseType(typeof(FirmaResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<FirmaResponse>> GetFirmaInfo()
    {
        var query = new GetFirmaInfoQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [HttpPost]
    [Route("InsertOrUpdateFirmaInfo")]
    [ProducesResponseType(typeof(FirmaResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<FirmaResponse>> InsertOrUpdateFirmaInfo([FromBody] InsertOrUpdateFirmaInfoCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
