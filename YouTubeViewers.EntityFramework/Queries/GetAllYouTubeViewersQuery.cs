using Microsoft.EntityFrameworkCore;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.Domain.Queries;

namespace YouTubeViewers.EntityFramework.Queries
{
    public class GetAllYouTubeViewersQuery : IGetAllYouTubeViewersQuery
    {
        private readonly YouTubeViewersDbContextFactory contextFactory;

        public GetAllYouTubeViewersQuery(YouTubeViewersDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<IEnumerable<YouTubeViewer>> Execute()
        {
            using YouTubeViewersDbContext context = contextFactory.Create();
            return (await context.YouTubeViewers.ToListAsync()).Select(y => new YouTubeViewer(y.ID, y.Username, y.IsSubscribed, y.IsMember));
        }
    }
}
