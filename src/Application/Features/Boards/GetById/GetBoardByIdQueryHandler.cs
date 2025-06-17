using Application.Interfaces;
using Contracts.Boards.Responses;
using Microsoft.VisualBasic;

namespace Application.Features.Boards.GetById
{
    public class GetBoardByIdQueryHandler
    {
        private readonly IBoardRepository _boardRepository;
        public GetBoardByIdQueryHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<BoardDetailResponse?> Handle(GetBoardByIdQuery request, CancellationToken cancellationToken)
        {
            var boardId = Guid.Parse(request.Id);
            var board = await _boardRepository.GetById(boardId, cancellationToken);
            if (board == null) return null;
            return new BoardDetailResponse
            {
                BoardId = board.Id.ToString(),
                Name = board.Name,
                Description = board.Description,
                CreatedAt = board.CreatedAt,
                UpdatedAt = board.UpdatedAt
            };
        }
    }
}