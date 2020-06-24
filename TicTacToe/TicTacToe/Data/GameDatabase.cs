namespace TicTacToe.Data
{
    using SQLite;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TicTacToe.Model;

    /// <summary>
    /// Defines the <see cref="GameDatabase" />.
    /// </summary>
    public class GameDatabase
    {
        /// <summary>
        /// Defines the _database.
        /// </summary>
        internal readonly SQLiteAsyncConnection _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameDatabase"/> class.
        /// </summary>
        /// <param name="dbPath">The dbPath<see cref="string"/>.</param>
        public GameDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Game>().Wait();
        }

        /// <summary>
        /// The GetGameResultsAsync.
        /// </summary>
        /// <returns>The <see cref="Task{List{Game}}"/>.</returns>
        public Task<List<Game>> GetGameResultsAsync()
        {
            return _database.Table<Game>().ToListAsync();
        }

        /// <summary>
        /// The SaveGameResultsAsync.
        /// </summary>
        /// <param name="game">The game<see cref="Game"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        public Task<int> SaveGameResultsAsync(Game game)
        {
            if (game.ID != 0)
            {
                return _database.UpdateAsync(game);
            }
            else
            {
                return _database.InsertAsync(game);
            }
        }
    }
}
