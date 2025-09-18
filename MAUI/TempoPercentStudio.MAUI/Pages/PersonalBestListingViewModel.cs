using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TempoPercentStudio.Entities.PersonalBests;

namespace TempoPercentStudio.MAUI.Pages
{
    public partial class PersonalBestListingViewModel(PersonalBestRepository repository) : ObservableObject
    {
        [ObservableProperty] private bool hasError;
        [ObservableProperty] private string errorMessage;

        public ObservableCollection<PersonalBestListingItemViewModel> PersonalBests { get; } = [];

        [RelayCommand]
        private async Task LoadPersonalBests()
        {
            HasError = false;

            try
            {
                PersonalBests.Clear();
                IEnumerable<PersonalBest> personalBests = await repository.GetAll();

                foreach (PersonalBest personalBest in personalBests) PersonalBests.Add(new PersonalBestListingItemViewModel(personalBest, OnPersonalBestDelete));
            }
            catch (Exception)
            {
                HasError = true;
                ErrorMessage = "Failed to load personal bests.";
            }
        }

        [RelayCommand]
        private async Task NavigateAddPersonalBest() => await Shell.Current.GoToAsync("AddPersonalBest");

        private async Task OnPersonalBestDelete(PersonalBestListingItemViewModel viewModel)
        {
            try
            {
                if (!await Shell.Current.DisplayAlert("Delete Personal Best", "Are you sure you want delete this personal best?", "Yes", "No")) return;
                await repository.Delete(viewModel.Id);
                await LoadPersonalBests();
            }
            catch(Exception) { await Shell.Current.DisplayAlert("Error", "Failed to delete personal best. Please try again.", "Ok"); }
        }
    }
}
