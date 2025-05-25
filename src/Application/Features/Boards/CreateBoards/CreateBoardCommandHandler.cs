using Application.Interfaces;
using Domain.Boards;

namespace Application.Features.Boards.CreateBoards
{

    /// <summary>
    /// Command to create a new board.
    /// </summary>
    public class CreateBoardCommandHandler
    {
        private readonly IBoardRepository _boardRepository;
        public CreateBoardCommandHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<Guid> Handle(CreateBoardCommand command, CancellationToken cancellationToken)
        { 
            try
            {
                var guid = Guid.NewGuid();
                var boardToRegister = new Board(
                    id: guid,
                    name: command.Name,
                    description: command.Description,
                    createdAt: DateTime.UtcNow,
                    updatedAt: null
                );

                await _boardRepository.CreateBoardAync(boardToRegister, cancellationToken);
                return boardToRegister.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating board: {ex.Message}");
                // Optionally log the exception here
                throw;
            }
        }

    }
}