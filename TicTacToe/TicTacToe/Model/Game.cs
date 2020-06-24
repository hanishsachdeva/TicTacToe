namespace TicTacToe.Model
{
    using SQLite;
    using System;

    /// <summary>
    /// Defines the <see cref="Game" />.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Winner.
        /// </summary>
        public string Winner { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsDraw.
        /// </summary>
        public bool IsDraw { get; set; }

        /// <summary>
        /// Gets or sets the Moves.
        /// </summary>
        public int Moves { get; set; }

        /// <summary>
        /// Gets or sets the DateUtc.
        /// </summary>
        public DateTime DateUtc { get; set; }
    }
}
