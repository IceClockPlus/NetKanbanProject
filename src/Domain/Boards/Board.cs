namespace Domain.Boards
{
    /// <summary>
    /// Represents a board in the system.
    /// This class is used to manage the details of a board, including its ID, name, description, creation date, and participants.
    /// </summary>
    public class Board
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; init; }
        public List<BoardParticipant> Participants { get; init; } = new List<BoardParticipant>();

        /// <summary>
        /// Default constructor for the Board class.
        /// This constructor is used to create a new instance of the Board class without any parameters.
        /// </summary>
        public Board()
        {
            // Default constructor for serialization
            Guid id = Guid.NewGuid();
            Name = string.Empty;
            Description = null;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = null;
        }

        public Board(
            Guid id,
            string name,
            string? description,
            DateTime createdAt,
            DateTime? updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }


    /// <summary>
    /// Represents a column in a board.
    /// This class is used to manage the columns of a board, which can contain tasks or items.
    /// </summary>
    public class BoardColumn
    {
        public required string Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public int? MaxTasks { get; init; }
        public List<BoardTask> Tasks { get; init; } = new List<BoardTask>();
        public int NumberOfTasks => Tasks.Count;
    }

    /// <summary>
    /// Represents a task in a board.
    /// This class is used to display taks within a board and show only the neccesary information.
    /// </summary>
    public class BoardTask
    {
        public required string Id { get; init; }
        public required string Title { get; init; }
        public TaskPriority Priority { get; init; }
        public BoardParticipant? AssignedTo { get; init; }
    }

    /// <summary>
    /// Represents the priority of a task in a board.
    /// This enum is used to categorize tasks based on their urgency and importance.
    /// </summary>
    public enum TaskPriority
    {
        ExtremelyLow,
        Low,
        Medium,
        High,
        ExtremelyHigh

    }


    /// <summary>
    /// Represents a participant in a board with their role and contact information.
    /// This class is used to manage the participants of a board, including their user ID, name, email, and role.
    /// </summary>
    public class BoardParticipant
    {
        public required string UserId { get; init; }
        public required string UserName { get; init; }
        public required string Email { get; init; }
        public required BoardRole Role { get; init; }
    }

    public enum BoardRole
    {
        Owner,
        Member,
        Viewer
    }
}