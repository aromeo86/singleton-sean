using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32.SafeHandles;
using System.Collections.ObjectModel;
using TempoPercentStudio.Entities.PersonalBests;

namespace TempoPercentStudio.MAUI.Pages
{
    public partial class PersonalBestListingViewModel : ObservableObject
    {
        [ObservableProperty] private bool isLoading;
        [ObservableProperty] private bool hasError;
        [ObservableProperty] private string errorMessage;

        public PersonalBestListingViewModel()
        {
            PersonalBests = [
                new(OnPersonalBestDelete),
                new(OnPersonalBestDelete),
                new(OnPersonalBestDelete)
                ];
        }

        public ObservableCollection<PersonalBestListingItemViewModel> PersonalBests { get; }

        [RelayCommand]
        private async Task NavigateAddPersonalBest() => await Shell.Current.GoToAsync("AddPersonalBest");

        private async Task OnPersonalBestDelete(PersonalBestListingItemViewModel viewModel)
        {
            if (!await Shell.Current.DisplayAlert("Delete Personal Best", "Are you sure you want delete this personal best?", "Yes", "No")) return;
            PersonalBests.Remove(viewModel);
        }
    }
}
