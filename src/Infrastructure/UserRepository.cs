using Domain.Interfaces.Repository;
using Domain.Models;
using Domain.Models.ValueObject;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public async Task Create(User obj, CancellationToken cancellationToken)
        {
            await Task.Run(() => Thread.Sleep(1000));
        }

        public async Task<User> Get(int id)
        {
            var document = new Document(Domain.Enums.EnumTypeDocument.Cpf, "12345678912");
            var name = new Name("Everton", "José", "Benedicto");
            var dateBirth = new DateTime(1987, 05, 30);
            var result = new User(1, document, name, dateBirth, "analista.everton@gmail.com");

            return await Task.Run(() => result);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var result = new List<User>();

            for (int i = 1; i <= 5; i++)
            {
                var document = new Document(Domain.Enums.EnumTypeDocument.Cpf, $"{i}2345678912");
                var name = new Name($"User-{i}", $"Middle-{i}", $"Last-{i}");
                var dateBirth = new DateTime(1987, 05, 29).AddDays(i);
                var user = new User(i, document, name, dateBirth, $"email.{i}@test.com");

                result.Add(user);
            }

            return await Task.Run(() => result);
        }

        public async Task Update(User obj, CancellationToken cancellationToken)
        {
            await Task.Run(() => Thread.Sleep(1000));
        }
    }
}