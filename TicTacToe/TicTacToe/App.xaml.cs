namespace TicTacToe
{
    using System;
    using System.IO;
    using TicTacToe.Data;
    using TicTacToe.View;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="App" />.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Defines the database.
        /// </summary>
        internal static GameDatabase database;

        /// <summary>
        /// Gets the Database.
        /// </summary>
        public static GameDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new GameDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GameResults.db3"));
                }
                return database;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomeView());
        }

        /// <summary>
        /// The OnStart.
        /// </summary>
        protected override void OnStart()
        {
        }

        /// <summary>
        /// The OnSleep.
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// The OnResume.
        /// </summary>
        protected override void OnResume()
        {
        }
    }
}
