using Domain.Participant;

namespace Domain.Projects
{
    public class ProjectCollaborator : Participant.ParticipantBase
    {
        public ProjectCollaborator(Guid userId, ParticipantName fullName, ParticipantEmail email) : base(userId, fullName, email)
        {
        }
    }
}