using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data;

public class UsermanagementContextFactory : IDesignTimeDbContextFactory<UsermanagementContext>
{
    public UsermanagementContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UsermanagementContext>();
        optionsBuilder.UseSqlServer("Data Source=UserManagement");
        return new UsermanagementContext(optionsBuilder.Options);
    }
}