using CadastroLivros.Core.DomainObjects;

namespace CadastroLivros.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
