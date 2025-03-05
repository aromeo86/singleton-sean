using System.ComponentModel.DataAnnotations;

namespace YouTubeViewers.EntityFramework.DTOs
{
    public class YouTubeViewerDto
    {
        [Key]
        public Guid ID { get; set; }
        public string Username { get; set; }
        public bool IsSubscribed { get; set; }
        public bool IsMember { get; set; }
    }
}
