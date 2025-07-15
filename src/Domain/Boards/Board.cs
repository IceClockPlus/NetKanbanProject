using Domain.Collaborators;
using Domain.Interfaces;
using Domain.Workspaces;
namespace Domain.Boards
{
    /// <summary>
    /// Represents a board in the system.
    /// This class is used to manage the details of a board, including its ID, name, description, creation date, and participants.
    /// </summary>
    public class Board : Workspace, ICollaborationalWorkSpace
    {
        private readonly List<BoardCollaborator> _collaborators = new();
        public IReadOnlyCollection<BoardCollaborator> Collaborators => _collaborators.AsReadOnly();

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
            List<BoardColumn> columns,
            List<BoardCollaborator> collaborators = null
            ) : base(id, name, description, createdAt, updatedAt)
        {
            _columns = columns;
            _collaborators = collaborators ?? new List<BoardCollaborator>();
        }

        public void AddCollaborator(ICollaborator participant)
        {
            var boardCollaborator = participant as BoardCollaborator;
            if (boardCollaborator == null)
            {
                throw new ArgumentException("Participant must be of type BoardCollaborator.", nameof(participant));
            }
            if (_collaborators.Any(c => c.UserId == boardCollaborator.UserId))
            {
                throw new InvalidOperationException("Collaborator already exists in the board.");
            }
            _collaborators.Add(boardCollaborator);
        }

        public void RemoveCollaborator(ICollaborator participant)
        {
            var boardCollaborator = participant as BoardCollaborator;
            if (boardCollaborator == null)
            {
                throw new ArgumentException("Participant must be of type BoardCollaborator.", nameof(participant));
            }

            if(Collaborators.Count == 1 && boardCollaborator.Role == CollaboratorRole.Admin)
            {
                throw new InvalidOperationException("Cannot remove the last admin collaborator from the board.");
            }

            if (!_collaborators.Remove(boardCollaborator))
            {
                throw new InvalidOperationException("Collaborator does not exist in the board.");
            }
        }

        public void DisableCollaborator(ICollaborator collaborator)
        {
            var boardCollaborator = collaborator as BoardCollaborator;
            if (boardCollaborator == null)
            {
                throw new ArgumentException("Collaborator must be of type BoardCollaborator.", nameof(collaborator));
            }
            var existingCollaborator = _collaborators.FirstOrDefault(c => c.UserId == boardCollaborator.UserId);
            if (existingCollaborator == null)
            {
                throw new InvalidOperationException("Collaborator does not exist in the board.");
            }
            existingCollaborator.DisableCollaborator();
        }
    }
}