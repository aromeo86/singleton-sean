using Microsoft.EntityFrameworkCore;
using System.Windows;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Queries;
using YouTubeViewers.EntityFramework;
using YouTubeViewers.EntityFramework.Commands;
using YouTubeViewers.EntityFramework.Queries;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF
{
    public partial class App : Application
    {
        private readonly YouTubeViewersDbContextFactory contextFactory;
        private readonly IGetAllYouTubeViewersQuery getAllYouTubeViewersQuery;
        private readonly ICreateYouTubeViewerCommand createYouTubeViewerCommand;
        private readonly IUpdateYouTubeViewerCommand updateYouTubeViewerCommand;
        private readonly IDeleteYouTubeViewerCommand deleteYouTubeViewerCommand;

        private readonly ModalNavigationStore modalNavigationStore;
        private readonly YouTubeViewersStore youTubeViewersStore;
        private readonly SelectedYouTubeViewerStore selectedYouTubeViewerStore;

        public App()
        {
            modalNavigationStore = new();
            contextFactory = new();
            getAllYouTubeViewersQuery = new GetAllYouTubeViewersQuery(contextFactory);
            createYouTubeViewerCommand = new CreateYouTubeViewerCommand(contextFactory);
            updateYouTubeViewerCommand = new UpdateYouTubeViewerCommand(contextFactory);
            deleteYouTubeViewerCommand = new DeleteYouTubeViewerCommand(contextFactory);

            youTubeViewersStore = new(getAllYouTubeViewersQuery, createYouTubeViewerCommand, updateYouTubeViewerCommand, deleteYouTubeViewerCommand);
            selectedYouTubeViewerStore = new(youTubeViewersStore);
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
