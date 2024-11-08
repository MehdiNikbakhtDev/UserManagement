using Application.Commands;
using Application.Contract.Enums;
using Application.Queries;
using Application.Responses;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers;

public class InsertOrUpdateFirmaInfoCommandHandler : IRequestHandler<InsertOrUpdateFirmaInfoCommand, FirmaResponse>
{
    private readonly IFirmaRepository _firmaRepository;
    private readonly IMapper _mapper;

    public InsertOrUpdateFirmaInfoCommandHandler(IFirmaRepository firmaRepository, IMapper mapper)
    {
        _firmaRepository = firmaRepository;
        _mapper = mapper;
    }
    public async Task<FirmaResponse> Handle(InsertOrUpdateFirmaInfoCommand request, CancellationToken cancellationToken)
    {
        var firmaInfoList = await _firmaRepository.GetFirmaInfo();
        #region [Insert or Update]
        if (firmaInfoList.Any(a => a.DataType == (int)DataTypeFirmaInfo.Address))
        {
            if (!string.IsNullOrWhiteSpace(request.Address))
            {
                var address = firmaInfoList.FirstOrDefault(a => a.DataType == (int)DataTypeFirmaInfo.Address);
                address.Value = request.Address;
                await _firmaRepository.UpdateAsync(address);
            }
        }
        else
        {
            var address = new FirmaInfo
            {
                DataType = (int)DataTypeFirmaInfo.Address,
                Value = request.Address
            };
            await _firmaRepository.AddAsync(address);
        }

        if (firmaInfoList.Any(a => a.DataType == (int)DataTypeFirmaInfo.PhoneNumber))
        {
            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                var phoneNumber = firmaInfoList.FirstOrDefault(a => a.DataType == (int)DataTypeFirmaInfo.PhoneNumber);
                phoneNumber.Value = request.PhoneNumber;
                await _firmaRepository.UpdateAsync(phoneNumber);
            }
        }
        else
        {
            var phoneNumber = new FirmaInfo
            {
                DataType = (int)DataTypeFirmaInfo.PhoneNumber,
                Value = request.PhoneNumber
            };
            await _firmaRepository.AddAsync(phoneNumber);
        }

        if (firmaInfoList.Any(a => a.DataType == (int)DataTypeFirmaInfo.Name))
        {
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                var name = firmaInfoList.FirstOrDefault(a => a.DataType == (int)DataTypeFirmaInfo.Name);
                name.Value = request.Name;
                await _firmaRepository.UpdateAsync(name);
            }
        }
        else
        {
            var name = new FirmaInfo
            {
                DataType = (int)DataTypeFirmaInfo.Name,
                Value = request.Name
            };
            await _firmaRepository.AddAsync(name);
        }
        #endregion [Insert or Update]

        firmaInfoList = await _firmaRepository.GetFirmaInfo();
        var output = new FirmaResponse
        {
            Address = firmaInfoList.FirstOrDefault(f => f.DataType == (int)DataTypeFirmaInfo.Address)?.Value,
            Name = firmaInfoList.FirstOrDefault(f => f.DataType == (int)DataTypeFirmaInfo.Name)?.Value,
            PhoneNumber = firmaInfoList.FirstOrDefault(f => f.DataType == (int)DataTypeFirmaInfo.PhoneNumber)?.Value
        };
        return output;
    }
}
