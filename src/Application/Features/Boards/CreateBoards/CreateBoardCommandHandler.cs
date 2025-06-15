using Application.Interfaces;
using Contracts.Boards.Responses;
using Domain.Boards;

namespace Application.Features.Boards.CreateBoards
{

    /// <summary>
    /// Command to create a new board.
    /// </summary>
    public class CreateBoardCommandHandler
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUserRepository _userRepository;
        public CreateBoardCommandHandler(IBoardRepository boardRepository, IUserRepository userRepository)
        {
            _boardRepository = boardRepository;
            _userRepository = userRepository;
        }

        public async Task<CreateBoardResponse> Handle(CreateBoardCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(Guid.Parse(command.UserId), cancellationToken);
                var guid = Guid.NewGuid();
                var boardToRegister = new Board(
                    id: guid,
                    name: command.Name,
                    description: command.Description,
                    createdAt: DateTime.UtcNow,
                    updatedAt: null,
                    columns: GenerateBoardColumns()
                );

                await _boardRepository.CreateBoardAync(boardToRegister, cancellationToken);

                CreateBoardResponse boardResponse = new()
                {
                    Id = boardToRegister.Id.ToString(),
                    Name = boardToRegister.Name,
                    Description = boardToRegister.Description
                };
                return boardResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating board: {ex.Message}");
                // Optionally log the exception here
                throw;
            }
        }

        private List<BoardColumn> GenerateBoardColumns()
        {
            List<BoardColumn> templateColumns = new List<BoardColumn>
            {
                new(Guid.NewGuid(), "To Do", Domain.Enums.BoardColumnType.Start, false, []),
                new(Guid.NewGuid(), "In Progress", Domain.Enums.BoardColumnType.InProgress, false, []),
                new(Guid.NewGuid(), "Done", Domain.Enums.BoardColumnType.End, false, [])
            };
            return templateColumns;
        }

    }
}