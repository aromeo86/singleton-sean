using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands
{
    public class OpenAddYouTubeViewerCommand : BaseCommand
    {
        private readonly YouTubeViewersStore youTubeViewersStore;
        private readonly ModalNavigationStore modalNavigationStore;

        public OpenAddYouTubeViewerCommand(YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            this.youTubeViewersStore = youTubeViewersStore;
            this.modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            AddYouTubeViewerViewModel addYouTubeViewerViewModel = new(youTubeViewersStore, modalNavigationStore);
            modalNavigationStore.CurrentViewModel = addYouTubeViewerViewModel;
        }
    }
}
