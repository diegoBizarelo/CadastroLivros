using CadastroLivros.Core.Data;
using CadastroLivros.Core.DomainObjects;
using CadastroLivros.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivros.Infrastructure.Repository
{
    public interface ILivroQuerie : IRepository<Livro>
    {
        Task<bool> Adicionar(Livro livro);
        Task<Livro> Atualizar(Livro livro);
        Task<IEnumerable<Livro>> BuscarLivros(string querie);
        Task<bool> Remover(Guid id);
    }
    public class LivroRepository : ILivroQuerie
    {
        private readonly CadastroLivrosContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public LivroRepository(CadastroLivrosContext context)
        {
            _context = context;
        }

        public async Task<bool> Adicionar(Livro livro)
        {
            await _context.Livros.AddAsync(livro);
            var r = await _context.CommitAsync();

            return r;
        }

        public async Task<Livro> Atualizar(Livro livro)
        {
            var l = await _context.Livros.FirstOrDefaultAsync(x => x.Id == livro.Id);
            if (l != null)
            {
                l.ISBN = livro.ISBN;
                l.DataLancamento = livro.DataLancamento;
                l.Editora = livro.Editora;
                l.Titulo = livro.Titulo;
                _context.Livros.Update(l);
                await _context.CommitAsync();
                return l;
            }

            return new Livro();
        }

        public async Task<IEnumerable<Livro>> BuscarLivros(string querie)
        {
            var result = await _context.Livros.Where(l => l.Titulo.Contains(querie)).ToListAsync();

            return result;
        }

        public async Task<bool> Remover(Guid id)
        {
            var livro = _context.Livros.FirstOrDefault(x => x.Id == id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
            }

            if (_context.ChangeTracker.HasChanges())
                await _context.CommitAsync();


            return livro != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
