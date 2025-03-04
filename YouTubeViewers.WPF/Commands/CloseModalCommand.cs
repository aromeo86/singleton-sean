using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.Commands
{
    public class CloseModalCommand : BaseCommand
    {
        private readonly ModalNavigationStore modalNavigationStore;

        public CloseModalCommand(ModalNavigationStore modalNavigationStore)
        {
            this.modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            modalNavigationStore.Close();
        }
    }
}
