using Domain.Participant;

namespace Domain.Boards
{
    public class BoardParticipant : ParticipantBase
    {
        public BoardParticipant(Guid userId, ParticipantName fullName, ParticipantEmail email)
        : base(userId, fullName, email)
        {

        }
    }
}