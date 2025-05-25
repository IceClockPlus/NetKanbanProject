using Domain.Boards;

namespace Application.Interfaces
{
    public interface IBoardRepository
    {
        Task<Guid> CreateBoardAync(Board board, CancellationToken cancellationToken);
    }
}