using Core.Contract;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data;

public class UsermanagementContext: DbContext
{
    public UsermanagementContext(DbContextOptions<UsermanagementContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<FirmaInfo> FirmaInfos { get; set; }
    public DbSet<MetaData> MetaDatas { get; set; }
}
