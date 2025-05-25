using Application.Features.Boards.CreateBoards;
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

            return services;
        }
    }
}