using Microsoft.EntityFrameworkCore;
using Todo.Application;
using Todo.Application.Contracts;
using Todo.Application.Implementations;
using Todo.Domain.RepositoryInterface;
using Todo.Infrastructure;
using Todo.Infrastructure.Persistence.Entities;
using Todo.Infrastructure.Repository;

namespace Todo.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DatabaseConnection");

            services.AddDbContext<TodoAppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddHealthChecks().AddDbContextCheck<TodoAppDbContext>();

            services.AddAutoMapper(typeof(InfraAssemblyMarker).Assembly); // register automapper only on infra layer

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITodoRepository, TodoRepository>();

            return services;
        }
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationLayerMarker).Assembly); // register automapper only on application layer

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
