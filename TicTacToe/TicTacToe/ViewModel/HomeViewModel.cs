namespace TicTacToe.ViewModel
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using TicTacToe.Model;
    using TicTacToe.View;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="HomeViewModel" />.
    /// </summary>
    public class HomeViewModel : BaseViewModel
    {
        /// <summary>
        /// Defines the isBarVisible.
        /// </summary>
        private bool isBarVisible;

        /// <summary>
        /// Gets or sets a value indicating whether IsBarVisible.
        /// </summary>
        public bool IsBarVisible
        {
            get => isBarVisible;
            set
            {
                isBarVisible = value;
                OnPropertyChanged("IsBarVisible");
            }
        }

        /// <summary>
        /// Defines the winWidth.
        /// </summary>
        private int winWidth;

        /// <summary>
        /// Gets or sets the WinWidth.
        /// </summary>
        public int WinWidth
        {
            get => winWidth;
            set
            {
                winWidth = value;
                OnPropertyChanged("WinWidth");
            }
        }

        /// <summary>
        /// Defines the loseWidth.
        /// </summary>
        private int loseWidth;

        /// <summary>
        /// Gets or sets the LoseWidth.
        /// </summary>
        public int LoseWidth
        {
            get => loseWidth;
            set
            {
                loseWidth = value;
                OnPropertyChanged("LoseWidth");
            }
        }

        /// <summary>
        /// Defines the winPercentage.
        /// </summary>
        private string winPercentage;

        /// <summary>
        /// Gets or sets the WinPercentage.
        /// </summary>
        public string WinPercentage
        {
            get => winPercentage;
            set
            {
                winPercentage = value;
                OnPropertyChanged("WinPercentage");
            }
        }

        /// <summary>
        /// Defines the gameResults.
        /// </summary>
        private List<Game> gameResults;

        /// <summary>
        /// Gets or sets the GameResults.
        /// </summary>
        public List<Game> GameResults
        {
            get => gameResults;
            set
            {
                gameResults = value;
                OnPropertyChanged("GameResults");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeViewModel"/> class.
        /// </summary>
        /// <param name="page">The page<see cref="Page"/>.</param>
        public HomeViewModel(Page page) : base(page)
        {
            PlayCommand = new Command(async () => await StartGame());

            LoadCommand = new Command(async () => await CalculateWinPercentage());
            GameResults = new List<Game>();
        }

        /// <summary>
        /// Gets or sets the PlayCommand.
        /// </summary>
        public ICommand PlayCommand { get; set; }

        /// <summary>
        /// Gets or sets the LoadCommand.
        /// </summary>
        public ICommand LoadCommand { get; set; }

        /// <summary>
        /// The StartGame.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        internal async Task StartGame()
        {
            await Page.Navigation.PushAsync(new GameView());
        }

        /// <summary>
        /// The CalculateWinPercentage.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task CalculateWinPercentage()
        {
            GameResults = await App.Database.GetGameResultsAsync();
            if (GameResults.Count > 0)
            {
                IsBarVisible = true;

                int winCount = GameResults.Count(x => x.Winner == "1");

                int winPercent = winCount * 100 / GameResults.Count;

                WinPercentage = winPercent.ToString() + " %";
                WinWidth = winPercent * 2;
                LoseWidth = 200 - WinWidth;
            }
        }
    }
}
