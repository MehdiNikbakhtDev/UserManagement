using Application.Contract.Enums;
using Application.Queries;
using Application.Responses;
using AutoMapper;
using Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers;

public class GetFirmaInfoQueryHandler : IRequestHandler<GetFirmaInfoQuery, FirmaResponse>
{
    private readonly IFirmaRepository _firmaRepository;
    private readonly IMapper _mapper;

    public GetFirmaInfoQueryHandler(IFirmaRepository firmaRepository, IMapper mapper)
    {
        _firmaRepository = firmaRepository;
        _mapper = mapper;
    }
    public async Task<FirmaResponse> Handle(GetFirmaInfoQuery request, CancellationToken cancellationToken)
    {
        var firmaInfoList = await _firmaRepository.GetFirmaInfo();
        var output = new FirmaResponse
        {
            Address = firmaInfoList.FirstOrDefault(f => f.Type == (int)DataTypeFirmaInfoEnum.Address)?.Value,
            Name  = firmaInfoList.FirstOrDefault(f => f.Type == (int)DataTypeFirmaInfoEnum.Name)?.Value,
            PhoneNumber = firmaInfoList.FirstOrDefault(f => f.Type == (int)DataTypeFirmaInfoEnum.PhoneNumber)?.Value
        };
        return output;
    }
}
