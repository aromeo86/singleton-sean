using YouTubeViewers.WPF.Models;

namespace YouTubeViewers.WPF.Stores
{
    public class SelectedYouTubeViewerStore
    {
        private YouTubeViewer selectedYouTubeViewer;

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
