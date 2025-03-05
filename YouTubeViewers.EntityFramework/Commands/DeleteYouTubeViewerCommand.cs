using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework.Commands
{
    public class DeleteYouTubeViewerCommand : IDeleteYouTubeViewerCommand
    {
        private readonly YouTubeViewersDbContextFactory contextFactory;

        public DeleteYouTubeViewerCommand(YouTubeViewersDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            using YouTubeViewersDbContext context = contextFactory.Create();
            YouTubeViewerDto youTubeViewerDto = new() { ID = id };

            context.YouTubeViewers.Remove(youTubeViewerDto);
            await context.SaveChangesAsync();
        }
    }
}
