using System.Collections.ObjectModel;
using YouTubeViewers.WPF.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersListingViewModel : ViewModelBase
    {
        public SelectedYouTubeViewerStore selectedYouTubeViewerStore { get; }
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel> youTubeViewersListingItemViewModels;
        public IEnumerable<YouTubeViewersListingItemViewModel> YouTubeViewersListingItemViewModels => youTubeViewersListingItemViewModels;

        private YouTubeViewersListingItemViewModel selectedYouTubeViewerViewModel;

        public YouTubeViewersListingItemViewModel SelectedYouTubeViewerViewModel
        {
            get => selectedYouTubeViewerViewModel;
            set
            {
                selectedYouTubeViewerViewModel = value;
                OnPropertyChanged(nameof(SelectedYouTubeViewerViewModel));

                selectedYouTubeViewerStore.SelectedYouTubeViewer = selectedYouTubeViewerViewModel?.YouTubeViewer;
            }
        }


        public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
        {
            this.selectedYouTubeViewerStore = selectedYouTubeViewerStore;

            youTubeViewersListingItemViewModels =
            [
                new YouTubeViewersListingItemViewModel(new YouTubeViewer("Mary", true, false)),
                new YouTubeViewersListingItemViewModel(new YouTubeViewer("Sean", true, false)),
                new YouTubeViewersListingItemViewModel(new YouTubeViewer("Alan", true, false)),
            ];
        }
    }
}
