using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Stores
{
    public class ModalNavigationStore : BaseViewModel
    {
        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }

        public bool IsOpen => CurrentViewModel is not null;

        public event Action CurrentViewModelChanged;

        public void Close()
        {
            CurrentViewModel = null;
        }
    }
}
