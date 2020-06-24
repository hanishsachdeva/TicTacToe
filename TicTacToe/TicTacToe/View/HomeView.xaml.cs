namespace TicTacToe.View
{
    using TicTacToe.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Defines the <see cref="HomeView" />.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        /// <summary>
        /// Defines the viewModel.
        /// </summary>
        internal HomeViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeView"/> class.
        /// </summary>
        public HomeView()
        {
            InitializeComponent();
            BindingContext = viewModel = new HomeViewModel(this);
        }

        /// <summary>
        /// The OnAppearing.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadCommand.Execute(null);
        }
    }
}
