using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands;

public class ConfirmUserCommand : IRequest<UserResponse>
{
    public string? RunGuid { get; set; }
    public string? Password { get; set; }
    public ConfirmUserCommand(string? runGuid, string? password)
    {
        RunGuid = runGuid;
        Password = password;
    }
}