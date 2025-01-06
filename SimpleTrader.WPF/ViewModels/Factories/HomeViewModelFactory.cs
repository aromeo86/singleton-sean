namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory : ISimpleTraderViewModelFactory<HomeViewModel>
    {
        private ISimpleTraderViewModelFactory<MajorIndexListingViewModel> majorIndexListingViewModelFactory;

        public HomeViewModelFactory(ISimpleTraderViewModelFactory<MajorIndexListingViewModel> majorIndexListingViewModelFactory) => this.majorIndexListingViewModelFactory = majorIndexListingViewModelFactory;

        public HomeViewModel CreateViewModel() => new(majorIndexListingViewModelFactory.CreateViewModel());
    }
}
