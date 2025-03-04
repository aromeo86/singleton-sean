namespace YouTubeViewers.WPF.Commands
{
    public abstract class AsyncBaseCommand : BaseCommand
    {
        public override async void Execute(object parameter)
        {
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception) { }
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}
