using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TempoPercentStudio.Entities.PersonalBests
{
    public partial class PersonalBestListingItemViewModel : ObservableObject
    {
        private readonly Func<PersonalBestListingItemViewModel, Task> onDelete;

        public string Distance { get; set; }
        public string Time { get; set; }

        public PersonalBestListingItemViewModel(Func<PersonalBestListingItemViewModel, Task> onDelete)
        {
            this.onDelete = onDelete;

            Distance = "400m";
            Time = "0:49.31";
        }

        [RelayCommand]
        private async Task DeletePersonalBest() => await onDelete(this);
    }
}
