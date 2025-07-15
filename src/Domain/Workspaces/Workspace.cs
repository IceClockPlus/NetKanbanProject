using Domain.Interfaces;

namespace Domain.Workspaces
{
    public abstract class Workspace
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

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
        /// <param name="collaborators">List of collaborators</param>
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