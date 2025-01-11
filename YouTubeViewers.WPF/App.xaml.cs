using System.Windows;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF
{
    public partial class App : Application
    {
        private readonly SelectedYouTubeViewerStore selectedYouTubeViewerStore;

        public App() => selectedYouTubeViewerStore = new();

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new YouTubeViewersViewModel(selectedYouTubeViewerStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
