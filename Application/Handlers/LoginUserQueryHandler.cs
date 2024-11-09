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

namespace Application.Handlers;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserResponse>
{
    private readonly IUsersRepository _userRepository;
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;
    private readonly AppSettingsHelper _appSettings;

    public LoginUserQueryHandler(
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
    public async Task<UserResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var userInfo = await _userRepository.GetUserByEmail(request.Email);
        if (userInfo.Password != request.Password.HashPassword())
            throw new ApplicationException("Fehler bei der Benutzer- oder Passwortanmeldung");
        return _mapper.Map<UserResponse>(userInfo);
    }
}
