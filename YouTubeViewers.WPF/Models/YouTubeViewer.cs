namespace YouTubeViewers.WPF.Models
{
    public class YouTubeViewer
    {
        public YouTubeViewer(Guid iD, string username, bool isSubscribed, bool isMember)
        {
            ID = iD;
            Username = username;
            IsSubscribed = isSubscribed;
            IsMember = isMember;
        }

        public Guid ID { get; }
        public string Username { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }
    }
}
