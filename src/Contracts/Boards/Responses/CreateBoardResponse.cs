namespace Contracts.Boards.Responses
{
    public record CreateBoardResponse
    {
        /// <summary>
        /// Represents the unique identifier of the created board.
        /// </summary>
        public required string Id { get; init; }

        /// <summary>
        /// Represents the name of the created board.
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Represents the description of the created board.
        /// </summary>
        public string? Description { get; init; }
    }
}