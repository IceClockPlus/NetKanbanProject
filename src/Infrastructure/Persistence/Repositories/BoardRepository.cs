using MongoDB.Driver;
using Domain.Boards;
using Application.Interfaces;
using Persistence.Entities;
using Persistence.Mappers;

namespace Persistence.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly IMongoCollection<BoardDocument> _boardCollection;

        public BoardRepository(IMongoDatabase database)
        {
            _boardCollection = database.GetCollection<BoardDocument>("Boards");
        }

        /// <summary>
        /// Creates a new board in the database.
        /// This method is asynchronous and returns the ID of the created board.
        /// </summary>
        /// <param name="board">Board to add</param>
        /// <returns>Created board GUID</returns>
        public async Task<Guid> CreateBoardAync(Board board, CancellationToken cancellationToken)
        {
            var boardDocument = board.ToDocument();
            await _boardCollection.InsertOneAsync(boardDocument, cancellationToken: cancellationToken);
            return board.Id;
        }
    }
}