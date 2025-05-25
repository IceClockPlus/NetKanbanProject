namespace Contracts.Boards.Requests
{
    public record CreateBoardRequest
    {
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; } = string.Empty;
    }
}