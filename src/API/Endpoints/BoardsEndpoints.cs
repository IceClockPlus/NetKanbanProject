using System.Diagnostics.Contracts;
using System.Security.Claims;
using Application.Features.Boards.CreateBoards;
using Application.Features.Boards.GetById;
using Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public static class BoardsEndpoints
    {
        public static void MapBoardsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/boards");
            group.WithTags("Boards");

            group.MapGet("/{id}", GetBoardById)
            .WithName("GetBoardById")
            .WithSummary("Get a board by its id")
            .Produces<Contracts.Boards.Responses.BoardDetailResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
                
            group.MapPost("/", CreateBoardAsync)
            .WithName("CreateBoard")
            .WithSummary("Creates a new board")
            .RequireAuthorization()
            .Produces<Contracts.Boards.Responses.CreateBoardResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Accepts<Contracts.Boards.Requests.CreateBoardRequest>("application/json");

        }

        private static async Task<IResult> GetBoardById([FromServices] GetBoardByIdQueryHandler handler, string id, CancellationToken cancellation)
        {
            var board = await handler.Handle(new GetBoardByIdQuery { Id = id }, cancellation);
            if (board == null) return Results.NotFound();
            return Results.Ok(board);
        }
        
        private static async Task<IResult> CreateBoardAsync(CreateBoardCommandHandler handler,
            ClaimsPrincipal user,
            [FromBody] Contracts.Boards.Requests.CreateBoardRequest request,
            CancellationToken cancellationToken)
        {
            string requesterUserId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            // Here you would typically call a service to create the board
            var createBoardCommand = new CreateBoardCommand
            {
                Name = request.Name,
                Description = request.Description,
                UserId = requesterUserId
            };
            var result = await handler.Handle(createBoardCommand, cancellationToken);

            // Returns 201 Created with the created board details
            return Results.Created($"/boards/{result}", result);
        }

    }
}