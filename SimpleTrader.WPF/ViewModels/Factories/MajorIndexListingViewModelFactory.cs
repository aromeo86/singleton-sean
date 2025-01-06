using SimpleTrader.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class MajorIndexListingViewModelFactory : ISimpleTraderViewModelFactory<MajorIndexListingViewModel>
    {
        private IMajorIndexService majorIndexService;

        public MajorIndexListingViewModelFactory(IMajorIndexService majorIndexService) => this.majorIndexService = majorIndexService;

        public MajorIndexListingViewModel CreateViewModel() => MajorIndexListingViewModel.LoadMajorIndexViewModel(majorIndexService);
    }
}
