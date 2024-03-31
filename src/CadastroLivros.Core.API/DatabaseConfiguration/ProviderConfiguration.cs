using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace CadastroLivros.Core.API.DatabaseConfiguration
{
    public class ProviderConfiguration
    {
        private readonly string _connectionString;
        public ProviderConfiguration With() => this;
        private static readonly string MigrationAssembly = typeof(ProviderConfiguration).GetTypeInfo().Assembly.GetName().Name;

        public static ProviderConfiguration Build(string connString)
        {
            return new ProviderConfiguration(connString);
        }

        public ProviderConfiguration(string connString)
        {
            _connectionString = connString;
        }

        public Action<DbContextOptionsBuilder> SqlServer =>
        options => options.UseSqlServer(_connectionString, sql => sql.MigrationsAssembly("CadastroLivros.Infrastructure"));

        public static (DatabaseType, string?) DetectDatabase(IConfiguration configuration) => (
        configuration.GetValue<DatabaseType>("AppSettings:DatabaseType", DatabaseType.None),
        configuration.GetConnectionString("DefaultConnection"));
    }
}
