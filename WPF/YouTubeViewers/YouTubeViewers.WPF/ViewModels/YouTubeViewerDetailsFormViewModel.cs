using System.Windows.Input;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewerDetailsFormViewModel : BaseViewModel
    {
        private string username;

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private bool isSubscribed;

        public bool IsSubscribed
        {
            get => isSubscribed;
            set
            {
                isSubscribed = value;
                OnPropertyChanged(nameof(IsSubscribed));
            }
        }

        private bool isMember;

        public bool IsMember
        {
            get => isMember;
            set
            {
                isMember = value;
                OnPropertyChanged(nameof(IsMember));
            }
        }

        private bool canSubmit;

        public bool CanSubmit => !string.IsNullOrWhiteSpace(Username);

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public YouTubeViewerDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }
    }
}
