using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands
{
    public class AddYouTubeViewerCommand : AsyncBaseCommand
    {
        private readonly AddYouTubeViewerViewModel addYouTubeViewerViewModel;
        private readonly YouTubeViewersStore youTubeViewersStore;
        private readonly ModalNavigationStore modalNavigationStore;

        public AddYouTubeViewerCommand(AddYouTubeViewerViewModel addYouTubeViewerViewModel, YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            this.addYouTubeViewerViewModel = addYouTubeViewerViewModel;
            this.youTubeViewersStore = youTubeViewersStore;
            this.modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await youTubeViewersStore.Add(new(Guid.NewGuid()
                    , addYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel.Username
                    , addYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel.IsSubscribed
                    , addYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel.IsMember));

                modalNavigationStore.Close();
            }
            catch (Exception) { }
        }
    }
}
