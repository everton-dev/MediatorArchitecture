using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces.Handlers
{
    public interface IHadlerBase<TResponse, TRequest>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}