using Domain.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public Task Create(User obj, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(User obj, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}