using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Collaborators
{
    public enum CollaboratorRole
    {
        Admin,
        Editor,
        Viewer
    }

    public interface ICollaborator
    {
        Guid UserId { get; }
        CollaboratorName Name { get; }
        CollaboratorEmail Email { get; }
        CollaboratorRole Role { get; }
        bool IsActive { get; }
        void DisableCollaborator();
    }
}
