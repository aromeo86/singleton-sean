using System.Collections.ObjectModel;
using System.Windows.Input;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersListingViewModel : BaseViewModel
    {
        public SelectedYouTubeViewerStore selectedYouTubeViewerStore { get; }

        private readonly YouTubeViewersStore youTubeViewersStore;
        private readonly ModalNavigationStore modalNavigationStore;
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


        public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore, YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            this.selectedYouTubeViewerStore = selectedYouTubeViewerStore;
            this.youTubeViewersStore = youTubeViewersStore;
            this.modalNavigationStore = modalNavigationStore;
            youTubeViewersListingItemViewModels = [];

            this.youTubeViewersStore.YouTubeViewerAdded += YouTubeViewersStore_YouTubeViewerAdded;
            this.youTubeViewersStore.YouTubeViewerUpdated += YouTubeViewersStore_YouTubeViewerUpdated;
        }

        protected override void Dispose()
        {
            youTubeViewersStore.YouTubeViewerAdded -= YouTubeViewersStore_YouTubeViewerAdded;
            
            base.Dispose();
        }

        private void YouTubeViewersStore_YouTubeViewerAdded(YouTubeViewer youTubeViewer)
        {
            AddYouTubeViewer(youTubeViewer);
        }

        private void YouTubeViewersStore_YouTubeViewerUpdated(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersListingItemViewModel viewer = youTubeViewersListingItemViewModels.FirstOrDefault(y => y.YouTubeViewer.ID == youTubeViewer.ID);

            if (viewer is not null) viewer.Update(youTubeViewer);
        }

        private void AddYouTubeViewer(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersListingItemViewModel item = new(youTubeViewer, youTubeViewersStore, modalNavigationStore);
            youTubeViewersListingItemViewModels.Add(item);
        }
    }
}
