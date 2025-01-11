using System.Windows.Input;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersViewModel : ViewModelBase
    {
        public YouTubeViewersListingViewModel YouTubeViewersListingViewModel;
        public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel;

        public ICommand AddYouTubeViewerCommand { get; set; }

        public YouTubeViewersViewModel()
        {
            YouTubeViewersListingViewModel = new();
            YouTubeViewersDetailsViewModel = new();
        }
    }
}
