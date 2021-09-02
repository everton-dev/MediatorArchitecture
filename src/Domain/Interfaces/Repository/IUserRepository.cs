using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    { 
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(int id);
    }
}