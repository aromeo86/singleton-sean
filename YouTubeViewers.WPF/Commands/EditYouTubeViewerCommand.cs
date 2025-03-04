using YouTubeViewers.WPF.Models;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands
{
    public class EditYouTubeViewerCommand : AsyncBaseCommand
    {
        private readonly EditYouTubeViewerViewModel editYouTubeViewerViewModel;
        private readonly YouTubeViewersStore youTubeViewersStore;
        private readonly ModalNavigationStore modalNavigationStore;

        public EditYouTubeViewerCommand(EditYouTubeViewerViewModel editYouTubeViewerViewModel, YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            this.editYouTubeViewerViewModel = editYouTubeViewerViewModel;
            this.youTubeViewersStore = youTubeViewersStore;
            this.modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await youTubeViewersStore.Update(new(editYouTubeViewerViewModel.YouTubeViewerId
                    , editYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel.Username
                    , editYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel.IsSubscribed
                    , editYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel.IsMember));

                modalNavigationStore.Close();
            }
            catch (Exception) { }
        }
    }
}
