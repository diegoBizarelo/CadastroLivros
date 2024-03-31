using CadastroLivros.Core.Data;
using CadastroLivros.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CadastroLivros.Infrastructure.Context
{
    public class CadastroLivrosContext : DbContext, IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        public DbSet<Livro> Livros { get; set; }

        public CadastroLivrosContext(DbContextOptions<CadastroLivrosContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public async Task<bool> CommitAsync()
        {
            var sucess = await base.SaveChangesAsync() > 0;

            return sucess;
        }
    }
}
