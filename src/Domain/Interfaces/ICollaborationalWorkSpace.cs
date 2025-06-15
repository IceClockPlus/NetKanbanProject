using Domain.Participant;

namespace Domain.Interfaces
{
    public interface ICollaborationalWorkSpace
    {
        public void AddParticipant(ParticipantBase participant);
        public void RemoveParticipant(ParticipantBase participant);
    }
}