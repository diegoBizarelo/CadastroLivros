using CadastroLivros.API.Dto;
using CadastroLivros.Core.API.Controllers;
using CadastroLivros.Core.DomainObjects;
using CadastroLivros.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CadastroLivros.API.Controllers
{
    [ApiController]
    public class LivrosController : MainController
    {
        private ILivroQuerie _livros { get; set; }

        public LivrosController(ILivroQuerie livros)
        {
            _livros = livros;
        }

        [HttpGet("{querie}")]
        public async Task<IList<LivroDto>> BuscarLivros(string querie)
        {
            var livros = await _livros.BuscarLivros(querie);

            Console.WriteLine("Chegou a requisição aqui");

            var l = toLivrosDto(livros);

            if (livros.Any())
            {
                return l.ToList();
            }

            return new List<LivroDto>();
        }

        [HttpDelete("")]
        public async void RemoverLivro(Guid id)
        {
            await _livros.Remover(id);
        }

        [HttpPut("")]
        public async Task<LivroDto> Atualizar(LivroDto livro)
        {
            
            var l = await _livros.Atualizar(toLivro(livro));
            return toLivroDto(l);
        }

        [HttpPost("")]
        public async Task<IActionResult> Adicionar(LivroDto livro)
        {
            var r = await _livros.Adicionar(toLivro(livro));

            if (r) return Ok(r);
            
            return NotFound();
        }

        private List<LivroDto> toLivrosDto(IEnumerable<Livro> livros)
        {
            var livrosDto = new List<LivroDto>();
            foreach(var livro in livros)
            {
                var l = new LivroDto();
                l.Id = livro.Id;
                l.DataLancamento = livro.DataLancamento;
                l.Editora = livro.Editora;
                l.ISBN = livro.ISBN;
                l.Titulo = livro.Titulo;
                livrosDto.Add(l);
            }
            return livrosDto;
        }

        private Livro toLivro(LivroDto livro)
        {
            var l = new Livro(livro.Id, livro.Titulo, livro.DataLancamento, livro.Editora, livro.ISBN);
            return l;
        }

        private LivroDto toLivroDto(Livro livro)
        {
            var l = new LivroDto(livro.Id, livro.Titulo, livro.DataLancamento, livro.Editora, livro.ISBN);
            return l;
        }
    }
}
