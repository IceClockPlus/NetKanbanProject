using Domain.Collaborators;

namespace Domain.Interfaces
{
    public interface ICollaborationalWorkSpace
    {

        public void AddCollaborator(ICollaborator participant);
        public void RemoveCollaborator(ICollaborator participant);
        public void DisableCollaborator(ICollaborator collaborator);
    }
}