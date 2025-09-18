using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.WPF.Stores
{
    public class SelectedYouTubeViewerStore
    {
        private readonly YouTubeViewersStore youTubeViewersStore;

        private YouTubeViewer selectedYouTubeViewer;

        public SelectedYouTubeViewerStore(YouTubeViewersStore youTubeViewersStore)
        {
            this.youTubeViewersStore = youTubeViewersStore;

            youTubeViewersStore.YouTubeViewerUpdated += YouTubeViewersStore_YouTubeViewerUpdated;
        }

        private void YouTubeViewersStore_YouTubeViewerUpdated(YouTubeViewer youTubeViewer)
        {
            if (youTubeViewer.ID == SelectedYouTubeViewer?.ID)
            {
                SelectedYouTubeViewer = youTubeViewer;
            }
        }

        public YouTubeViewer SelectedYouTubeViewer
        {
            get => selectedYouTubeViewer;
            set
            {
                selectedYouTubeViewer = value;
                SelectedYouTubeViewerChanged?.Invoke();
            }
        }

        public event Action SelectedYouTubeViewerChanged;
    }
}
