namespace Application.Interfaces
{
    public interface IBoardRepository
    {
        Task<Guid> CreateBoardAync();
    }
}