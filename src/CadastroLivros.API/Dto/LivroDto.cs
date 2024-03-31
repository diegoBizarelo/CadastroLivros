namespace CadastroLivros.API.Dto
{
    public class LivroDto
    {
        public LivroDto() { }

        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public DateTime? DataLancamento { get; set; }
        public string? Editora { get; set; }
        public string? ISBN { get; set; }

        public LivroDto(Guid id, string titulo, DateTime? dataLancamento, string editora, string iSBN)
        {
            Id = id;
            Titulo = titulo;
            DataLancamento = dataLancamento;
            Editora = editora;
            ISBN = iSBN;
        }
    }
}
