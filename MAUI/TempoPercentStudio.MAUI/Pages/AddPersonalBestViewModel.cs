using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TempoPercentStudio.Entities.PersonalBests;

namespace TempoPercentStudio.MAUI.Pages
{
    public partial class AddPersonalBestViewModel(PersonalBestRepository repository) : ObservableObject
    {
        [ObservableProperty] private double distance;
        [ObservableProperty] private int minutes;
        [ObservableProperty] private int seconds;
        [ObservableProperty] private string milliseconds;

        [RelayCommand]
        private async Task Submit()
        {
            try 
            {
                string paddedMilliseconds = Milliseconds.PadRight(3, '0');
                await repository.Create(new NewPersonalBest(Distance, new(0, 0, Minutes, Seconds, int.Parse(paddedMilliseconds)))); 
            }
            catch(Exception) { await Shell.Current.DisplayAlert("Error", "Failed to create personal best. Please try again.", "Ok"); }

            await Shell.Current.GoToAsync("..");
        }
    }
}
