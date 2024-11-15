﻿using Application.Queries;
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

public class GetUserByEmailQueryHandler: IRequestHandler<GetUserByEmailQuery, UserResponse>
{
    private readonly IUsersRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByEmailQueryHandler(IUsersRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UserResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var userInfo = await _userRepository.GetUserByEmail(request.Email);
        return _mapper.Map<UserResponse>(userInfo);
    }
}
