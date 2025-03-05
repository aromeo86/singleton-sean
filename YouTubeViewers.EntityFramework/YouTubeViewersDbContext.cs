using Microsoft.EntityFrameworkCore;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework
{
    public class YouTubeViewersDbContext : DbContext
    {
        private string connectionStrings = "Data source=YouTubeViewers.db";

        public YouTubeViewersDbContext() : base()
        {
        }

        public DbSet<YouTubeViewerDto> YouTubeViewers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionStrings);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
