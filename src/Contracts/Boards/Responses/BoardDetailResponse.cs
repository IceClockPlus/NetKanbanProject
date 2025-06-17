namespace Contracts.Boards.Responses
{
    public class BoardDetailResponse
    {
        public required string BoardId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}