using Application.Responses;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Application.Commands;

namespace API.Controllers;
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("GetUserInfo")]
    [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UserResponse>> GetUserInfo([FromQuery] GetUserByEmailQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [HttpPost]
    [Route("RegistrierUser")]
    [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UserResponse>> RegistrierUser([FromBody] RegistrierUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPost]
    [Route("ConfirmUser")]
    [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UserResponse>> ConfirmUser([FromBody] ConfirmUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }


    [HttpPost]
    [Route("LoginUser")]
    [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UserResponse>> LoginUser([FromBody] LoginUserQuery command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
