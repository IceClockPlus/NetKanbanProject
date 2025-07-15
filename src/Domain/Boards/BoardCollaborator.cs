using Domain.Collaborators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Boards
{
    public class BoardCollaborator : ICollaborator
    {
        public Guid UserId { get; private set; }
        public CollaboratorName Name { get; private set; }
        public CollaboratorEmail Email { get; private set; }
        public CollaboratorRole Role { get; private set; }
        public bool IsActive { get; private set; } = true;
        public void DisableCollaborator()
        {
            IsActive = false;
        }
        public BoardCollaborator(Guid userId, CollaboratorName name, CollaboratorEmail email, CollaboratorRole role, bool isActive = true)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Role = role;
            IsActive = isActive;
        }
        // Additional methods or properties can be added here if needed
    }
}
