using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework.Commands
{
    public class CreateYouTubeViewerCommand : ICreateYouTubeViewerCommand
    {
        private readonly YouTubeViewersDbContextFactory contextFactory;

        public CreateYouTubeViewerCommand(YouTubeViewersDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task Execute(YouTubeViewer youTubeViewer)
        {
            using YouTubeViewersDbContext context = contextFactory.Create();
            YouTubeViewerDto youTubeViewerDto = new()
            {
                ID = youTubeViewer.ID,
                Username = youTubeViewer.Username,
                IsMember = youTubeViewer.IsMember,
                IsSubscribed = youTubeViewer.IsSubscribed
            };

            context.YouTubeViewers.Update(youTubeViewerDto);
            await context.SaveChangesAsync();
        }
    }
}
