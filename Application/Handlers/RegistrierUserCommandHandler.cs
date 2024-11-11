using Application.Commands;
using Application.Contract.Enums;
using Application.Responses;
using AutoMapper;
using Core.Entities;
using Core.Helper;
using Core.Repositories;
using Core.Services;
using MediatR;
using Microsoft.Extensions.Options;

namespace Application.Handlers;

public class RegistrierUserCommandHandler : IRequestHandler<RegistrierUserCommand, UserResponse>
{
    private readonly IUsersRepository _userRepository;
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;
    private readonly AppSettingsHelper _appSettings;

    public RegistrierUserCommandHandler(
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
    public async Task<UserResponse> Handle(RegistrierUserCommand request, CancellationToken cancellationToken)
    {

        var allUser = await _userRepository.GetAllUser();
      
        if (allUser.Any(a => a.Email == request.Email))
        {
            throw new ApplicationException("Ein Benutzer hat sich bereits mit dieser E-Mail registriert");
        }

        string runGuid = Guid.NewGuid().ToString();
        string returnLink = $"{_appSettings.AppAddress}/user-confirmation/{runGuid}";
        string body = string.Format(_appSettings.EmailBody, returnLink);
        await _emailService.SendEmailAsync(request.Email, body);
        var userInfo = new User
        {
            Email = request.Email,
            Name = request.Name,
            Password = null,
            RunGuid = runGuid,
            Status = (int?)UserStatusEnum.Registered,
            InsertionDateTime = DateTime.Now,
            LastUpdateDateTime = DateTime.Now,
        };
        await _userRepository.AddAsync(userInfo);
        return _mapper.Map<UserResponse>(userInfo);
    }
}
