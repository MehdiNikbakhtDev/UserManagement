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
    public DbSet<User> User { get; set; }
    public DbSet<FirmaInfo> FirmaInfo { get; set; }
    public DbSet<MetaData> MetaData { get; set; }
}
