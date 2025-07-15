namespace Persistence.Mappers
{
    using Domain.Boards;
    using Entities;

    /// <summary>
    /// Mapper for converting between Board and BoardDocument.
    /// </summary>
    public static class BoardMapper
    {
        /// <summary>
        /// Converts a Board to a BoardDocument.
        /// </summary>
        public static BoardDocument ToDocument(this Board board)
        {
            return new BoardDocument
            {
                Id = board.Id,
                Name = board.Name,
                Description = board.Description,
                CreatedAt = board.CreatedAt,
                UpdatedAt = board.UpdatedAt,
                Columns = board.Columns.Select(c => new BoardColumnDocument
                {
                    ColumnId = c.ColumnId,
                    Name = c.Name,
                    ColumnType = (int)c.ColumnType,
                }).ToList(),
                Collaborators = board.Collaborators.Select(collaborator => new BoardCollaboratorDocument
                {
                    Id = collaborator.UserId,
                    FirstName = collaborator.Name.FirstName,
                    LastName = collaborator.Name.LastName,
                    Email = collaborator.Email.Address,
                    IsActive = collaborator.IsActive,
                    Role = (int)collaborator.Role
                }).ToList()
            };
        }

        /// <summary>
        /// Converts a BoardDocument to a Board.
        /// </summary>
        public static Board ToDomain(this BoardDocument document)
        {
            return new Board(
                id: document.Id,
                name: document.Name,
                description: document.Description,
                createdAt: document.CreatedAt,
                updatedAt: document.UpdatedAt,
                columns: [.. document.Columns.Select(c => c.ToDomain())]
            );

        }

        /// <summary>
        /// Convert the column documents into the domain
        /// </summary>
        /// <param name="columnDocument"></param>
        /// <returns></returns>
        public static BoardColumn ToDomain(this BoardColumnDocument columnDocument)
        {
            return new(
                id: columnDocument.ColumnId,
                name: columnDocument.Name,
                columnType: (Domain.Enums.BoardColumnType)columnDocument.ColumnType,
                blockWhenReachLimit: columnDocument.BlockWhenLimitReached,
                workItems: [.. columnDocument.WorkItems.Select(w => w.ToDomain())],
                maxItems: columnDocument.MaxItems
            );
        }

        /// <summary>
        /// Convert work item inside the board into the domain
        /// </summary>
        /// <param name="workItemDocument"></param>
        /// <returns></returns>
        public static BoardWorkItem ToDomain(this BoardWorkItemDocument workItemDocument)
        {
            return new(
                id: workItemDocument.WorkItemId,
                name: workItemDocument.Name,
                assignTo: workItemDocument.AssignedTo?.ToDomain(),
                points: workItemDocument.Points,
                priority: (Domain.Enums.WorkItemPriority?)workItemDocument.Priority
            );
        }

        /// <summary>
        /// Convert collaborator in Board collection into the domain
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static BoardCollaborator ToDomain(this BoardCollaboratorDocument document)
        {
            return new BoardCollaborator(
                userId: document.Id,
                name: new(document.FirstName, null, document.LastName),
                email: new(document.Email),
                role: (Domain.Collaborators.CollaboratorRole)document.Role,
                isActive: document.IsActive
            );
        }
    
    }
}