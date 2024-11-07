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
    Task<IEnumerable<User>> GetUserByEmail(string email);
}
