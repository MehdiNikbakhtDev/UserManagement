using Core.Common;
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
    public async Task<IEnumerable<User>> GetUserByEmail(string email)
    {
        var userList = await _dbContext.User
            .Where(o => o.Email == email)
            .ToListAsync();
        return userList;
    }
   
}