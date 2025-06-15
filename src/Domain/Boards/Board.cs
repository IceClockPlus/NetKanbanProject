using Domain.Workspaces;
namespace Domain.Boards
{
    /// <summary>
    /// Represents a board in the system.
    /// This class is used to manage the details of a board, including its ID, name, description, creation date, and participants.
    /// </summary>
    public class Board : Workspace
    {
        private readonly List<BoardColumn> _columns = new();
        public IReadOnlyCollection<BoardColumn> Columns => _columns.AsReadOnly();
        /// <summary>
        /// Default constructor for the Board class.
        /// This constructor is used to create a new instance of the Board class without any parameters.
        /// </summary>
        /// 
        public Board(
            Guid id,
            string name,
            string? description,
            DateTime createdAt,
            DateTime? updatedAt,
            List<BoardColumn> columns
            ) : base(id, name, description, createdAt, updatedAt)
        {
            _columns = columns;
        }
    }
}