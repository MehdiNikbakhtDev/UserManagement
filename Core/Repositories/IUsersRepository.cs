using Core.Common;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories;

public interface IUsersRepository : IAsyncRepository<User>
{
    Task<User> GetUserByEmail(string email);
    Task<IEnumerable<User>> GetAllUser();
    Task<User> GetUserByguid(string? runGuid);
}
