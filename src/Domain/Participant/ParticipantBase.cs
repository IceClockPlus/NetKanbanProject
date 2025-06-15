namespace Domain.Participant
{
    /// <summary>
    /// Base class of participant in a project
    /// </summary>
    public abstract class ParticipantBase
    {
        public Guid UserId { get; private set; }
        public ParticipantName FullName { get; private set; }
        public ParticipantEmail Email { get; private set; }
        public ParticipantBase(Guid userId, ParticipantName fullName, ParticipantEmail email)
        {
            UserId = userId;
            FullName = fullName;
            Email = email; 
        }
    }
}