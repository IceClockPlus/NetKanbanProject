namespace Domain.WorkItem
{
    /// <summary>
    /// Represents a participant in a work item with their ID, name, and avatar URL.
    /// </summary>
    public class WorkItemParticipant
    {
        public required string Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public string? AvatarUrl { get; init; }
    }

}