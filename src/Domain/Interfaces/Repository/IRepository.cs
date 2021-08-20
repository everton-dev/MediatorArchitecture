using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity obj, CancellationToken cancellationToken);
        Task Update(TEntity obj, CancellationToken cancellationToken);
    }
}