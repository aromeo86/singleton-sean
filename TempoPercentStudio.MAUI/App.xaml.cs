using SQLite;
using TempoPercentStudio.Entities.PersonalBests;
using TempoPercentStudio.Shared.Database;

namespace TempoPercentStudio.MAUI
{
    public partial class App : Application
    {
        private readonly SqliteConnectionFactory _sqliteConnectionFactory;

        public App(SqliteConnectionFactory sqliteConnectionFactory)
        {
            InitializeComponent();
            _sqliteConnectionFactory = sqliteConnectionFactory;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        protected override async void OnStart()
        {
            try
            {
                ISQLiteAsyncConnection connection = _sqliteConnectionFactory.Connect();
                await connection.CreateTableAsync<PersonalBestDto>();
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Failed to initialize database.", "Ok");
            }
            
            base.OnStart();
        }
    }
}