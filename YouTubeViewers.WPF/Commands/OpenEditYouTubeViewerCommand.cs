using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands
{
    public class OpenEditYouTubeViewerCommand : BaseCommand
    {
        private readonly YouTubeViewersListingItemViewModel youTubeViewersListingItemViewModel;
        private readonly ModalNavigationStore modalNavigationStore;
        private YouTubeViewersStore youTubeViewersStore;

        public OpenEditYouTubeViewerCommand(YouTubeViewersListingItemViewModel youTubeViewersListingItemViewModel, YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            this.youTubeViewersListingItemViewModel = youTubeViewersListingItemViewModel;
            this.youTubeViewersStore = youTubeViewersStore;
            this.modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            YouTubeViewer youTubeViewer = youTubeViewersListingItemViewModel.YouTubeViewer;

            EditYouTubeViewerViewModel editYouTubeViewerViewModel = new(youTubeViewer, youTubeViewersStore, modalNavigationStore);
            modalNavigationStore.CurrentViewModel = editYouTubeViewerViewModel;
        }
    }
}
