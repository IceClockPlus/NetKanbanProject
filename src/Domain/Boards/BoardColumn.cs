using Domain.Enums;

namespace Domain.Boards
{
    public class BoardColumn
    {
        public Guid ColumnId { get; private set; }
        public string Name { get; private set; }
        public int? MaxItems { get; private set; }
        public BoardColumnType ColumnType { get; private set; }
        public bool BlockWhenMaxLimitIsReached { get; private set; }
        private readonly List<BoardWorkItem> _workItems = new();
        public IReadOnlyCollection<BoardWorkItem> WorkItems => _workItems.AsReadOnly();
        public int NumberOfItems => WorkItems.Count;

        /// <summary>
        /// Change board column name
        /// </summary>
        /// <param name="name">New board column name to change</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Name cannot be null");
            Name = name;
        }

        public void DisableBlockLimit()
        {
            BlockWhenMaxLimitIsReached = false;
        }

        public void EnableBlockLimit()
        {
            if (!MaxItems.HasValue)
                throw new ArgumentException("Max Limit is not established");

            if (WorkItems.Count > MaxItems)
                throw new ArgumentException($"Column {Name} already reached the limit");

            BlockWhenMaxLimitIsReached = true;
        }

        /// <summary>
        /// Get work item inside column by its ID
        /// </summary>
        /// <param name="id">Work item Id</param>
        /// <returns>Returns the work item if exists, otherwise null</returns>
        public BoardWorkItem? GetWorkItem(Guid id) => WorkItems.FirstOrDefault(w => w.Id == id);

        public void AddWorkItem(BoardWorkItem workItem)
        {
            bool isReachedLimit = MaxItems.HasValue && (NumberOfItems > MaxItems);
            if (BlockWhenMaxLimitIsReached && isReachedLimit)
            {
                throw new ArgumentException("Cannot add item because limit is reached");
            }
            _workItems.Add(workItem);
        }

        public void RemoveWorkItem(Guid id)
        {
            var workItemToRemove = GetWorkItem(id) ?? throw new ArgumentNullException("Item not found");
            _workItems.Remove(workItemToRemove);
        }

        public BoardColumn()
        {
            Name = string.Empty;
            BlockWhenMaxLimitIsReached = false;
        }

        public BoardColumn(Guid id,
            string name,
            BoardColumnType columnType,
            bool blockWhenReachLimit,
            List<BoardWorkItem> workItems,
            int? maxItems = null)
        {
            ColumnId = id;
            Name = name;
            ColumnType = columnType;
            BlockWhenMaxLimitIsReached = blockWhenReachLimit;
            _workItems = workItems;
            MaxItems = maxItems;
        }

    }
}