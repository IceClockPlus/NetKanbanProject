namespace Persistence.Entities
{
    public class BoardWorkItemDocument
    {
        public Guid WorkItemId { get; set; }
        public required string Name { get; set; }
        public int? Priority { get; set; }
        public int? Points { get; set; }
        public BoardCollaboratorDocument? AssignedTo { get; set; }
    }
}