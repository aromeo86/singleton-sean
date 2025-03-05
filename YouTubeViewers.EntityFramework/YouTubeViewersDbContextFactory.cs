using Microsoft.EntityFrameworkCore;

namespace YouTubeViewers.EntityFramework
{
    public class YouTubeViewersDbContextFactory
    {
        public YouTubeViewersDbContext Create()
        {
            return new();
        }
    }
}
