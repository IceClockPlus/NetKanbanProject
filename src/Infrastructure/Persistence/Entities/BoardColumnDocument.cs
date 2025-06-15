namespace Persistence.Entities
{
    public class BoardColumnDocument
    {
        public Guid ColumnId { get; set; }
        public required string Name { get; set; }
        public int? MaxItems { get; set; }
        public int ColumnType { get; set; }
        public bool BlockWhenLimitReached { get; set; }
        public List<BoardWorkItemDocument> WorkItems { get; set; } = new();
    }
}