using Application.Commands;
using Application.Contract.Enums;
using Application.Queries;
using Application.Responses;
using AutoMapper;
using Core.Entities;
using Core.Helper;
using Core.Repositories;
using Core.Services;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers;

public class ConfirmUserCommandHandler : IRequestHandler<ConfirmUserCommand, UserResponse>
{
    private readonly IUsersRepository _userRepository;
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;
    private readonly AppSettingsHelper _appSettings;

    public ConfirmUserCommandHandler(
        IUsersRepository userRepository,
        IEmailService emailService,
        IMapper mapper, IOptions<AppSettingsHelper> appSettings
        )

    {
        _userRepository = userRepository;
        _emailService = emailService;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }
    public async Task<UserResponse> Handle(ConfirmUserCommand request, CancellationToken cancellationToken)
    {

        User? userInfo = await _userRepository.GetUserByguid(request.RunGuid);
        if (userInfo == null)
        {
            throw new ApplicationException("Der Link ist defekt");
        }
        if (string.IsNullOrWhiteSpace(request.Password))
        {
            throw new ApplicationException("Das Passwort ist leer");
        }
        if (!string.IsNullOrWhiteSpace(userInfo.Password))
        {
            throw new ApplicationException("Das Passwort wurde bereits festgelegt");
        }
        userInfo.Password = request.Password.HashPassword();
        userInfo.LastUpdateDateTime = DateTime.Now;
        userInfo.Status = (int?)UserStatusEnum.Confirmed;
        await _userRepository.UpdateAsync(userInfo);
        return _mapper.Map<UserResponse>(userInfo);
    }
}
