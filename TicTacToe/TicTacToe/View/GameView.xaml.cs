namespace TicTacToe.View
{
    using Acr.UserDialogs;
    using TicTacToe.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Defines the <see cref="GameView" />.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameView : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameView"/> class.
        /// </summary>
        public GameView()
        {
            InitializeComponent();
            BindingContext = new GameViewModel(this);
        }

        /// <summary>
        /// The OnBackButtonPressed.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        protected override bool OnBackButtonPressed()
        {
            UserDialogs.Instance.ConfirmAsync("Are you sure you want to leave your current game?", "Leave game").ContinueWith((exit) =>
            {
                if (exit.Result)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PopAsync();
                    });
                }
            });

            return true;
        }
    }
}
