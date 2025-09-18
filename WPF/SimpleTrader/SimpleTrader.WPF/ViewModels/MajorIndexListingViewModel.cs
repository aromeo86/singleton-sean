using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.WPF.ViewModels
{
    public class MajorIndexListingViewModel : ViewModelBase
    {
        private readonly IMajorIndexService majorIndexService;

        private MajorIndex dowJones { get; set; }
        private MajorIndex nasdaq { get; set; }
        private MajorIndex sP500 { get; set; }

        
        public MajorIndex DowJones 
        {
            get => dowJones;
            set
            {
                dowJones = value;
                OnPropertyChanged(nameof(DowJones));
            }
        }
        
        public MajorIndex Nasdaq 
        {
            get => nasdaq;
            set
            {
                nasdaq = value;
                OnPropertyChanged(nameof(Nasdaq));
            }
        }
        
        public MajorIndex SP500 
        {
            get => sP500;
            set 
            {
                sP500 = value;
                OnPropertyChanged(nameof(SP500));
            }
        }

        public MajorIndexListingViewModel(IMajorIndexService majorIndexService) => this.majorIndexService = majorIndexService;

        public static MajorIndexListingViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            MajorIndexListingViewModel majorIndexViewModel = new(majorIndexService);
            majorIndexViewModel.LoadMajorIndexes();
            return majorIndexViewModel;
        }

        private void LoadMajorIndexes()
        {
            majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(task =>
            {
                if (task.Exception is null) DowJones = task.Result;
            });

            majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith(task =>
            {
                if (task.Exception is null) Nasdaq = task.Result;
            });

            majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith(task =>
            {
                if (task.Exception is null) SP500 = task.Result;
            });
        }
    }
}
