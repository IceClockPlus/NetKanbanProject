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
                UpdatedAt = board.UpdatedAt
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
                updatedAt: document.UpdatedAt
            );
          
        }
    }
}