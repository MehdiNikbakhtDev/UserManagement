﻿using Core.Common;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;
public class UsersRepository : RepositoryBase<User>, IUsersRepository
{
    public UsersRepository(UsermanagementContext dbContext) : base(dbContext)
    {
    }
    public async Task<User> GetUserByEmail(string email)
    {
        var userInfo = await _dbContext.User
            .FirstOrDefaultAsync(o => o.Email == email);
        return userInfo;
    }
    public async Task<IEnumerable<User>> GetAllUser()
    {
        var userList = await _dbContext.User
            .ToListAsync();
        return userList;
    }
    public async Task<User> GetUserByguid(string? runGuid)
    {
        var userInfo= await _dbContext.User
            .FirstOrDefaultAsync(f=>f.RunGuid==runGuid);
        return userInfo;
    }


}