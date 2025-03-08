using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TempoPercentStudio.Entities.PersonalBests;
using TempoPercentStudio.Features.CalculateTempo;

namespace TempoPercentStudio.MAUI.Pages
{
    public partial class CalculateTempoViewModel(PersonalBestRepository repository) : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(DistanceOutput))]
        [NotifyPropertyChangedFor(nameof(TimeOutput))]
        private int percentEffort = 50;
        
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(DistanceOutput))]
        [NotifyPropertyChangedFor(nameof(TimeOutput))]
        private CalculateTempoPersonaleBestViewModel selectedPersonalBest;
        
        [ObservableProperty] private bool hasError;
        [ObservableProperty] private string errorMessage;

        public string DistanceOutput => SelectedPersonalBest?.Distance;
        public string TimeOutput 
        {
            get 
            {
                if (SelectedPersonalBest is null) return TimeSpan.Zero.ToString();

                double percentEffortDecimal = PercentEffort / 100.0;
                double personalBestMilliseconds = SelectedPersonalBest.PersonalBest.Time.TotalMilliseconds;

                return TimeSpan.FromMilliseconds((2 - percentEffortDecimal) * personalBestMilliseconds).ToString();
            }
        }

        public ObservableCollection<CalculateTempoPersonaleBestViewModel> PersonalBests { get; } = [];

        [RelayCommand]
        private async Task LoadPersonalBests()
        {
            HasError = false;

            try
            {
                PersonalBests.Clear();
                IEnumerable<PersonalBest> personalBests = await repository.GetAll();

                foreach (PersonalBest personalBest in personalBests) PersonalBests.Add(new CalculateTempoPersonaleBestViewModel(personalBest));
            }
            catch (Exception)
            {
                HasError = true;
                ErrorMessage = "Failed to load personal bests.";
            }
        }
    }
}
