using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Core.API.DatabaseConfiguration
{
    public static class ContextConfiguration
    {
        public static IServiceCollection Persistence<TContext>(this IServiceCollection services, Action<DbContextOptionsBuilder> databaseConfig) where TContext : DbContext
        {
            // Add a DbContext to store Keys. SigningCredentials and DataProtectionKeys
            if (services.All(x => x.ServiceType != typeof(TContext)))
                services.AddDbContext<TContext>(databaseConfig);
            return services;
        }
    }
}
