using Domain.Boards;

namespace Application.Interfaces
{
    public interface IBoardRepository
    {
        Task<Board?> GetById(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateBoardAync(Board board, CancellationToken cancellationToken);
    }
}