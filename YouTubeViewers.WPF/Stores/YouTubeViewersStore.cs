using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.Domain.Queries;

namespace YouTubeViewers.WPF.Stores
{
    public class YouTubeViewersStore
    {
        private readonly IGetAllYouTubeViewersQuery getAllYouTubeViewersQuery;
        private readonly ICreateYouTubeViewerCommand createYouTubeViewerCommand;
        private readonly IUpdateYouTubeViewerCommand updateYouTubeViewerCommand;
        private readonly IDeleteYouTubeViewerCommand deleteYouTubeViewerCommand;

        public YouTubeViewersStore(IGetAllYouTubeViewersQuery getAllYouTubeViewersQuery,
            ICreateYouTubeViewerCommand createYouTubeViewerCommand, 
            IUpdateYouTubeViewerCommand updateYouTubeViewerCommand, 
            IDeleteYouTubeViewerCommand deleteYouTubeViewerCommand)
        {
            this.getAllYouTubeViewersQuery = getAllYouTubeViewersQuery;
            this.createYouTubeViewerCommand = createYouTubeViewerCommand;
            this.updateYouTubeViewerCommand = updateYouTubeViewerCommand;
            this.deleteYouTubeViewerCommand = deleteYouTubeViewerCommand;
        }

        public event Action<YouTubeViewer> YouTubeViewerAdded;
        public event Action<YouTubeViewer> YouTubeViewerUpdated;

        public async Task Add(YouTubeViewer youTubeViewer)
        {
            await createYouTubeViewerCommand.Execute(youTubeViewer);
            YouTubeViewerAdded?.Invoke(youTubeViewer);
        }

        public async Task Update(YouTubeViewer youTubeViewer)
        {
            await updateYouTubeViewerCommand.Execute(youTubeViewer);
            YouTubeViewerUpdated?.Invoke(youTubeViewer);
        }
    }
}
