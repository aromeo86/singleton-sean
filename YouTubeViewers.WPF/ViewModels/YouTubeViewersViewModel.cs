using System.Windows.Input;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersViewModel : BaseViewModel
    {
        public YouTubeViewersListingViewModel YouTubeViewersListingViewModel { get; }
        public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel { get; }

        public ICommand AddYouTubeViewerCommand { get; set; }

        public YouTubeViewersViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore, YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewersListingViewModel = new(selectedYouTubeViewerStore, youTubeViewersStore, modalNavigationStore);
            YouTubeViewersDetailsViewModel = new(selectedYouTubeViewerStore);

            AddYouTubeViewerCommand = new OpenAddYouTubeViewerCommand(youTubeViewersStore, modalNavigationStore);
        }
    }
}
