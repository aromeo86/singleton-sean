using System.Windows;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF
{
    public partial class App : Application
    {
        private readonly ModalNavigationStore modalNavigationStore;
        private readonly YouTubeViewersStore youTubeViewersStore;
        private readonly SelectedYouTubeViewerStore selectedYouTubeViewerStore;

        public App()
        {
            modalNavigationStore = new();
            youTubeViewersStore = new();
            selectedYouTubeViewerStore = new();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            YouTubeViewersViewModel youTubeViewersViewModel = new(selectedYouTubeViewerStore, youTubeViewersStore, modalNavigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(modalNavigationStore, youTubeViewersViewModel)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
