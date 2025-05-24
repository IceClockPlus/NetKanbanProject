namespace Application.Features.Boards.CreateBoards
{

    /// <summary>
    /// Command to create a new board.
    /// </summary>
    public class CreateBoardCommand
    {
        /// <summary>
        /// Represents the name of the board to create.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Represents the description of the board to create.
        /// This property is optional and can be null if not specified.
        /// </summary>
        public string? Description { get; set; }
    }
}