using System.Windows.Input;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersViewModel : ViewModelBase
    {
        public YouTubeViewersListingViewModel YouTubeViewersListingViewModel;
        public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel;

        public ICommand AddYouTubeViewerCommand { get; set; }

        public YouTubeViewersViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
        {
            YouTubeViewersListingViewModel = new(selectedYouTubeViewerStore);
            YouTubeViewersDetailsViewModel = new(selectedYouTubeViewerStore);
        }
    }
}
