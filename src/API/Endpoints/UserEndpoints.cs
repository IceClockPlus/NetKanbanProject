using Application.Features.Users.CreateUser;
using Contracts.Boards.Requests;
using Contracts.Users.Request;
using Contracts.Users.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/users")
                .WithTags("Users");

            group.MapPost("/", CreateUserAsync)
            .WithName("CreateUser")
            .WithSummary("Register a new user")
            .Produces<CreateUserResponse>(StatusCodes.Status201Created)
            .Accepts<CreateBoardRequest>("application/json");

        }

        private static async Task<IResult> CreateUserAsync(CreateUserCommandHandler handler,
        [FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            CreateUserCommand command = new()
            {
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };
            var result = await handler.Handle(command, cancellationToken);

            return Results.Created($"/users/{result!.Id}", result);
        }
    }

}