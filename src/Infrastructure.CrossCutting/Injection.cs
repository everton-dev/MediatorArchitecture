using Domain.Interfaces.Repository;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Application.CrossCutting
{
    public static class Injection
    {
        public static void InjectInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}