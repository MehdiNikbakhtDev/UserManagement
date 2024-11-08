using Application.Responses;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{email}", Name = "GetOrdersByUserName")]
    [ProducesResponseType(typeof(IEnumerable<UserResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetUserByEmail(string email)
    {
        var query = new GetUserByEmailQuery(email);
        var users = await _mediator.Send(query);
        return Ok(users);
    }

}
