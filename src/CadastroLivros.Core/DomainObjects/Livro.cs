using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Core.DomainObjects
{
    public class Livro : Entity, IAggregateRoot
    {
        public Livro() { }

        public string? Titulo { get; set; }
        public DateTime? DataLancamento { get; set; }
        public string? Editora { get; set; }
        public string? ISBN { get; set; }

        public Livro(Guid id, string titulo, DateTime? dataLancamento, string editora, string iSBN) : base(id)
        {
            Titulo = titulo;
            DataLancamento = dataLancamento;
            Editora = editora;
            ISBN = iSBN;
        }
    }
}
