namespace Domain.WorkItem
{
    /// <summary>
    /// Represents a work item in the system.
    /// This class is used to manage the details of a work item, including its ID, title, description, creation date, and status.
    /// </summary>
    public class WorkItem
    {
        public required string Id { get; init; }
        public required string Title { get; init; }
        public string? Description { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

        /// <summary>
        /// Represents who created the work item.
        /// This property is optional and can be null if not specified.
        /// </summary>
        public WorkItemParticipant? CreatedBy { get; init; }
    }

    public class WorkItemTask : WorkItem
    {
        public required string BoardId { get; init; }
        public required string ColumnId { get; init; }
        public WorkItemParticipant? AssignedTo { get; init; }
        public WorkItemParticipant? InformedBy { get; init; }
    }
}