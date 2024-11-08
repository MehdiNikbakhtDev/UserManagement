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
public class FirmaRepository : RepositoryBase<FirmaInfo>, IFirmaRepository
{
    public FirmaRepository(UsermanagementContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<FirmaInfo>> GetFirmaInfo()
    {
        var FirmaInfoList = await _dbContext.FirmaInfo
           .ToListAsync();
        return FirmaInfoList;
    }
}
   
