using Domain.Enums;
using Domain.Participant;

namespace Domain.Boards
{
    public class BoardWorkItem
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public BoardParticipant? AssignTo { get; private set; }
        public int? Points { get; private set; }
        public WorkItemPriority? Priority { get; private set; }

        public void ReassignWorkItem(BoardParticipant? participant)
        {
            AssignTo = participant;
        }

        public void UpdateWorkPoints(int? newPoints)
        {
            Points = newPoints;
        }

        public void ChangePriority(WorkItemPriority? newPriority)
        {
            Priority = newPriority;
        }

        public BoardWorkItem()
        {
            Name = string.Empty;
        }

        public BoardWorkItem(Guid id,
        string name,
        BoardParticipant? assignTo,
        int? points, WorkItemPriority? priority)
        {
            Id = id;
            Name = name;
            AssignTo = assignTo;
            Points = points;
            Priority = priority;
        }
    }
}