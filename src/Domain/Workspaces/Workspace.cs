using Domain.Interfaces;
using Domain.Participant;

namespace Domain.Workspaces
{
    public abstract class Workspace : ICollaborationalWorkSpace
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        private readonly List<ParticipantBase> _collaborators = new();
        public IReadOnlyCollection<ParticipantBase> Collaborators => _collaborators.AsReadOnly();
        public void AddParticipant(ParticipantBase participant)
        {
            _collaborators.Add(participant);
        }

        public void RemoveParticipant(ParticipantBase participant)
        {
            var existingCollaborator = _collaborators.FirstOrDefault(c => c.UserId == participant.UserId) ?? throw new Exception("Collaborator does not exist");
            _collaborators.Remove(existingCollaborator);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Workspace()
        {
            Name = string.Empty;
            Description = null;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = null;
        }

        /// <summary>
        /// Constructor to create workspaces
        /// </summary>
        /// <param name="id">Workspace ID</param>
        /// <param name="name">Workspace name</param>
        /// <param name="description">Workspace description</param>
        /// <param name="createdAt">Workspace creation date</param>
        /// <param name="updatedAt">Workspace latest update date</param>
        public Workspace(
            Guid id,
            string name,
            string? description,
            DateTime createdAt,
            DateTime? updatedAt
        )
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        
    }
}