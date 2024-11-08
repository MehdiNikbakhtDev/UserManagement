using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;

namespace Infrastructure.Extensions;
public static class ConfigureServices
{

    public static IServiceCollection AddInfraServices(this IServiceCollection serviceCollection,
     IConfiguration configuration)
    {
        serviceCollection.AddDbContext<UsermanagementContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("UsermanagementConnectionString")));

        serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        serviceCollection.AddScoped<IUsersRepository, UsersRepository>();
        serviceCollection.AddScoped<IFirmaRepository, FirmaRepository>();
        return serviceCollection;
    }
}


