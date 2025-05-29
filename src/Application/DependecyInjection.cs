using Application.Features.Boards.CreateBoards;
using Application.Features.Users.CreateUser;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register application services and features here
            // For example, you can register MediatR handlers, AutoMapper profiles, etc.
            services.AddScoped<CreateBoardCommandHandler>();
            services.AddScoped<CreateUserCommandHandler>();

            return services;
        }
    }
}