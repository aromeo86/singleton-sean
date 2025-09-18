using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersDetailsViewModel : BaseViewModel
    {
        private SelectedYouTubeViewerStore selectedYouTubeViewerStore;
        private YouTubeViewer SelectedYouTubeViewer => selectedYouTubeViewerStore.SelectedYouTubeViewer;

        public bool HasSelectedYouTubeViewer => SelectedYouTubeViewer is not null;
        public string Username => SelectedYouTubeViewer?.Username ?? "Unknown";
        public string IsSubscribedDisplay => SelectedYouTubeViewer?.IsSubscribed ?? false ? "YES" : "NO";
        public string IsMemberDisplay => SelectedYouTubeViewer?.IsMember ?? false ? "YES" : "NO";

        public YouTubeViewersDetailsViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
        {
            this.selectedYouTubeViewerStore = selectedYouTubeViewerStore;
            this.selectedYouTubeViewerStore.SelectedYouTubeViewerChanged += SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged;
        }

        protected override void Dispose()
        {
            selectedYouTubeViewerStore.SelectedYouTubeViewerChanged -= SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged;
            base.Dispose();
        }

        private void SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged()
        {
            OnPropertyChanged(nameof(HasSelectedYouTubeViewer));
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(IsSubscribedDisplay));
            OnPropertyChanged(nameof(IsMemberDisplay));
        }
    }
}
