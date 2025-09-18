using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TempoPercentStudio.Entities.PersonalBests
{
    public partial class PersonalBestListingItemViewModel(PersonalBest personalBest, Func<PersonalBestListingItemViewModel, Task> onDelete = null) : ObservableObject
    {
        private readonly PersonalBest personalBest = personalBest;
        private readonly Func<PersonalBestListingItemViewModel, Task> onDelete = onDelete;

        public int Id => personalBest.Id;
        public string Distance => personalBest.Distance.ToString();
        public string Time => personalBest.Time.ToString();

        [RelayCommand]
        private async Task DeletePersonalBest() => await onDelete(this);
    }
}
