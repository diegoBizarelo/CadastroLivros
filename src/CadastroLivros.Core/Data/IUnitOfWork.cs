namespace CadastroLivros.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}