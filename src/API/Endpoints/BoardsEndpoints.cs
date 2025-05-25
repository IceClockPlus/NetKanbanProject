using Application.Features.Boards.CreateBoards;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public static class BoardsEndpoints
    {
        public static void MapBoardsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/boards");
            group.WithTags("Boards");

            group.MapPost("/", CreateBoardAsync)
                .WithName("CreateBoard")
                .WithSummary("Creates a new board")
                .Produces<Contracts.Boards.Responses.CreateBoardResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Accepts<Contracts.Boards.Requests.CreateBoardRequest>("application/json");

        }
        
        private static async Task<IResult> CreateBoardAsync(CreateBoardCommandHandler handler,
            [FromBody] Contracts.Boards.Requests.CreateBoardRequest request,
            CancellationToken cancellationToken)
        {
            // Here you would typically call a service to create the board
            var createBoardCommand = new CreateBoardCommand
            {
                Name = request.Name,
                Description = request.Description
            };
            var result = await handler.Handle(createBoardCommand, cancellationToken);

            // Returns 201 Created with the created board details
            return Results.Created($"/boards/{result}", result);            
        }

    }
}