using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands;

public class InsertOrUpdateFirmaInfoCommand : IRequest<FirmaResponse>
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }

    public InsertOrUpdateFirmaInfoCommand(string? name, string? address, string? phoneNumber)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
    }
}