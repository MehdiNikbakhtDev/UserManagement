using Core.Common;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories;

public interface IFirmaRepository : IAsyncRepository<FirmaInfo>
{
    Task<List<FirmaInfo>> GetFirmaInfo();
}
