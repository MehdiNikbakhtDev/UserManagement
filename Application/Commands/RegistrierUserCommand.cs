using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands;

public class RegistrierUserCommand : IRequest<UserResponse>
{
    public string? Email { get; set; }
    public string? Name { get; set; }
    public bool? IsHauptUser { get; set; }
    public RegistrierUserCommand(string? email, string? name, bool? isHauptUser)
    {
        Email = email;
        Name = name;
        IsHauptUser = isHauptUser;
    }
}