namespace TicTacToe.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="BaseViewModel" />.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the Page.
        /// </summary>
        protected Page Page { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        /// <param name="page">The page<see cref="Page"/>.</param>
        public BaseViewModel(Page page)
        {
            Page = page;
        }

        /// <summary>
        /// Defines the PropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The OnPropertyChanged.
        /// </summary>
        /// <param name="propertyName">The propertyName<see cref="string"/>.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
