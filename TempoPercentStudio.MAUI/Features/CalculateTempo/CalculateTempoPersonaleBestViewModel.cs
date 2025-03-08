using CommunityToolkit.Mvvm.ComponentModel;
using TempoPercentStudio.Entities.PersonalBests;

namespace TempoPercentStudio.Features.CalculateTempo
{
    public partial class CalculateTempoPersonaleBestViewModel(PersonalBest personalBest) : ObservableObject
    {
        public PersonalBest PersonalBest = personalBest;

        public int Id => PersonalBest.Id;
        public string Distance => PersonalBest.Distance.ToString();
        public string Time => PersonalBest.Time.ToString();
    }
}
