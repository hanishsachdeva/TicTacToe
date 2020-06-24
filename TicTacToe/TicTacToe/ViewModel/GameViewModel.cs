namespace TicTacToe.ViewModel
{
    using Acr.UserDialogs;
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using TicTacToe.Model;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="GameViewModel" />.
    /// </summary>
    public class GameViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the CurrentGame.
        /// </summary>
        public string[,] CurrentGame { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Player1Up.
        /// </summary>
        internal bool Player1Up { get; set; } = true;

        /// <summary>
        /// Gets or sets the Moves.
        /// </summary>
        internal int Moves { get; set; } = 0;

        /// <summary>
        /// Defines the gameOver.
        /// </summary>
        internal bool gameOver;

        /// <summary>
        /// Gets or sets a value indicating whether GameOver.
        /// </summary>
        public bool GameOver
        {
            get { return gameOver; }
            set
            {
                gameOver = value;
                OnPropertyChanged("GameOver");
            }
        }

        /// <summary>
        /// Defines the result.
        /// </summary>
        internal string result;

        /// <summary>
        /// Gets or sets the Result.
        /// </summary>
        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }

        /// <summary>
        /// Gets or sets the Source.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Defines the imageSource.
        /// </summary>
        internal string imageSource;

        /// <summary>
        /// Gets or sets the ImageSource.
        /// </summary>
        public string ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }

        /// <summary>
        /// Defines the isBusy.
        /// </summary>
        internal bool isBusy;

        /// <summary>
        /// Gets or sets a value indicating whether IsBusy.
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameViewModel"/> class.
        /// </summary>
        /// <param name="page">The page<see cref="Page"/>.</param>
        public GameViewModel(Page page) : base(page)
        {
            CurrentGame = new string[3, 3];

            DoneCommand = new Command(Done);
        }

        /// <summary>
        /// Defines the currentStatus.
        /// </summary>
        internal string currentStatus;

        /// <summary>
        /// Gets or sets the CurrentStatus.
        /// </summary>
        public string CurrentStatus
        {
            get { return currentStatus; }
            set
            {
                currentStatus = value;
                OnPropertyChanged("CurrentStatus");
            }
        }

        /// <summary>
        /// Defines the play0.
        /// </summary>
        internal string play0 = string.Empty;

        /// <summary>
        /// Gets or sets the Play0.
        /// </summary>
        public string Play0
        {
            get { return play0; }
            set
            {
                play0 = value;
                OnPropertyChanged("Play0");
            }
        }

        /// <summary>
        /// Defines the play1.
        /// </summary>
        internal string play1 = string.Empty;

        /// <summary>
        /// Gets or sets the Play1.
        /// </summary>
        public string Play1
        {
            get { return play1; }
            set
            {
                play1 = value;
                OnPropertyChanged("Play1");
            }
        }

        /// <summary>
        /// Defines the play2.
        /// </summary>
        internal string play2 = string.Empty;

        /// <summary>
        /// Gets or sets the Play2.
        /// </summary>
        public string Play2
        {
            get { return play2; }
            set
            {
                play2 = value;
                OnPropertyChanged("Play2");
            }
        }

        /// <summary>
        /// Defines the play3.
        /// </summary>
        internal string play3 = string.Empty;

        /// <summary>
        /// Gets or sets the Play3.
        /// </summary>
        public string Play3
        {
            get { return play3; }
            set
            {
                play3 = value;
                OnPropertyChanged("Play3");
            }
        }

        /// <summary>
        /// Defines the play4.
        /// </summary>
        internal string play4 = string.Empty;

        /// <summary>
        /// Gets or sets the Play4.
        /// </summary>
        public string Play4
        {
            get { return play4; }
            set
            {
                play4 = value;
                OnPropertyChanged("Play4");
            }
        }

        /// <summary>
        /// Defines the play5.
        /// </summary>
        internal string play5 = string.Empty;

        /// <summary>
        /// Gets or sets the Play5.
        /// </summary>
        public string Play5
        {
            get { return play5; }
            set
            {
                play5 = value;
                OnPropertyChanged("Play5");
            }
        }

        /// <summary>
        /// Defines the play6.
        /// </summary>
        internal string play6 = string.Empty;

        /// <summary>
        /// Gets or sets the Play6.
        /// </summary>
        public string Play6
        {
            get { return play6; }
            set
            {
                play6 = value;
                OnPropertyChanged("Play6");
            }
        }

        /// <summary>
        /// Defines the play7.
        /// </summary>
        internal string play7 = string.Empty;

        /// <summary>
        /// Gets or sets the Play7.
        /// </summary>
        public string Play7
        {
            get { return play7; }
            set
            {
                play7 = value;
                OnPropertyChanged("Play7");
            }
        }

        /// <summary>
        /// Defines the play8.
        /// </summary>
        internal string play8 = string.Empty;

        /// <summary>
        /// Gets or sets the Play8.
        /// </summary>
        public string Play8
        {
            get { return play8; }
            set
            {
                play8 = value;
                OnPropertyChanged("Play8");
            }
        }

        /// <summary>
        /// Defines the resetCommand.
        /// </summary>
        internal Command resetCommand;

        /// <summary>
        /// Gets or sets the DoneCommand.
        /// </summary>
        public ICommand DoneCommand { get; set; }

        /// <summary>
        /// Gets the ResetCommand.
        /// </summary>
        public Command ResetCommand
        {
            get
            {
                return resetCommand ??
                  (resetCommand = new Command(() =>
                  {
                      CurrentGame = new string[3, 3];
                      Player1Up = true;
                      GameOver = false;
                      Moves = 0;
                  }));
            }
        }

        /// <summary>
        /// Defines the playCommand.
        /// </summary>
        internal Command<string> playCommand;

        /// <summary>
        /// Gets the PlayCommand.
        /// </summary>
        public Command<string> PlayCommand
        {
            get
            {
                return playCommand ??
                    (playCommand = new Command<string>(async (p) => await Play(p)));
            }
        }

        /// <summary>
        /// The Play.
        /// </summary>
        /// <param name="number">The number<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        internal async Task Play(string number)
        {
            if (GameOver)
                return;

            int x = 0;
            int y = 0;
            switch (number)
            {
                case "0":
                    break;
                case "1":
                    x = 1;
                    y = 0;
                    break;
                case "2":
                    x = 2;
                    y = 0;
                    break;
                case "3":
                    x = 0;
                    y = 1;
                    break;
                case "4":
                    x = 1;
                    y = 1;
                    break;
                case "5":
                    x = 2;
                    y = 1;
                    break;
                case "6":
                    x = 0;
                    y = 2;
                    break;
                case "7":
                    x = 1;
                    y = 2;
                    break;
                case "8":
                    x = 2;
                    y = 2;
                    break;
                default:
                    return;
            }

            if (CurrentGame[x, y] != null)
                return;

            if (Player1Up)
            {
                CurrentGame[x, y] = "x_1x3.png";
            }
            else
            {
                CurrentGame[x, y] = "o_1x3.png";
            }

            Player1Up = !Player1Up;

            switch (number)
            {
                case "0":
                    Play0 = CurrentGame[x, y];
                    break;
                case "1":
                    Play1 = CurrentGame[x, y];
                    break;
                case "2":
                    Play2 = CurrentGame[x, y];
                    break;
                case "3":
                    Play3 = CurrentGame[x, y];
                    break;
                case "4":
                    Play4 = CurrentGame[x, y];
                    break;
                case "5":
                    Play5 = CurrentGame[x, y];
                    break;
                case "6":
                    Play6 = CurrentGame[x, y];
                    break;
                case "7":
                    Play7 = CurrentGame[x, y];
                    break;
                case "8":
                    Play8 = CurrentGame[x, y];
                    break;
                default:
                    return;
            }

            Moves++;
            await CheckResults();
        }

        //check for win or draw.
        /// <summary>
        /// The CheckResults.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        internal async Task CheckResults()
        {
            //Conditions for winning the game
            string[,] winningCombos =
            {
                {CurrentGame[0,0], CurrentGame[0,1], CurrentGame[0,2]},
                {CurrentGame[1,0], CurrentGame[1,1], CurrentGame[1,2]},
                {CurrentGame[2,0], CurrentGame[2,1], CurrentGame[2,2]},
                {CurrentGame[0,0], CurrentGame[1,0], CurrentGame[2,0]},
                {CurrentGame[0,1], CurrentGame[1,1], CurrentGame[2,1]},
                {CurrentGame[0,2], CurrentGame[1,2], CurrentGame[2,2]},
                {CurrentGame[0,0], CurrentGame[1,1], CurrentGame[2,2]},
                {CurrentGame[0,2], CurrentGame[1,1], CurrentGame[2,0]}
            };

            for (int i = 0; i < 8; i++)
            {
                if ((winningCombos[i, 0] == "x_1x3.png") && (winningCombos[i, 1] == "x_1x3.png") && (winningCombos[i, 2] == "x_1x3.png"))
                {
                    GameOver = true;
                    Result = "You Win!";
                    ImageSource = "face_happy_x3.png";
                    await InsertWinner(1);
                    return;
                }

                if ((winningCombos[i, 0] == "o_1x3.png") && (winningCombos[i, 1] == "o_1x3.png") && (winningCombos[i, 2] == "o_1x3.png"))
                {
                    GameOver = true;
                    Result = "You Lose!";
                    ImageSource = "face_sad_x3.png";
                    await InsertWinner(2);
                    return;
                }

            }


            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (CurrentGame[x, y] == null)
                        return;
                }
            }

            //Draw!
            GameOver = true;
            CurrentStatus = "Game is a draw!";
            Result = "That's a draw!";
            ImageSource = "face_indifferent_x3.png";
            await InsertWinner(0);
        }

        /// <summary>
        /// The InsertWinner.
        /// </summary>
        /// <param name="winner">The winner<see cref="int"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        internal async Task InsertWinner(int winner)
        {
            var game = new Game
            {
                Winner = winner.ToString(),
                IsDraw = winner == 0,
                Moves = Moves
            };

            var progress = UserDialogs.Instance.Loading("Saving game...", maskType: MaskType.Gradient);
            try
            {
                IsBusy = true;
                await App.Database.SaveGameResultsAsync(game);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                progress.Hide();
                IsBusy = false;
            }
        }

        /// <summary>
        /// The Done.
        /// </summary>
        internal void Done()
        {
            UserDialogs.Instance.ConfirmAsync("Are you sure you want to leave your current game?", "Leave game").ContinueWith((exit) =>
            {
                if (exit.Result)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Page.Navigation.PopAsync();
                    });
                }
            });
        }
    }
}
