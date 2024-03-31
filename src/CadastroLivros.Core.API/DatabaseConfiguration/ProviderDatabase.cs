using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static CadastroLivros.Core.API.DatabaseConfiguration.ProviderConfiguration;

namespace CadastroLivros.Core.API.DatabaseConfiguration
{
    public enum DatabaseType
    {
        None,
        SqlServer,
    }

    public static class ProviderDatabase
    {
        public static IServiceCollection ConfigureProviderForContext<TContext>(
            this IServiceCollection services,
             (DatabaseType, string) options) where TContext : DbContext
        {
            var (database, connString) = options;
            /*return database switch
            {
                DatabaseType.SqlServer => services.Persistence<TContext>(Build(connString).With().SqlServer),
                _ => throw new ArgumentOutOfRangeException(nameof(database), database, null)
            };*/
            return services.Persistence<TContext>(Build(connString).With().SqlServer);
        }

        
    }
}
