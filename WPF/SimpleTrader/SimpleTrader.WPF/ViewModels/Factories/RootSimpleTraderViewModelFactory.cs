using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class RootSimpleTraderViewModelFactory : IRootSimpleTraderViewModelFactory
    {
        private readonly ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory;
        private readonly BuyViewModel buyViewModel;

        public RootSimpleTraderViewModelFactory(ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory, ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory, BuyViewModel buyViewModel)
        {
            this.homeViewModelFactory = homeViewModelFactory;
            this.portfolioViewModelFactory = portfolioViewModelFactory;
            this.buyViewModel = buyViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.Home => homeViewModelFactory.CreateViewModel(),
                ViewType.Portfolio => portfolioViewModelFactory.CreateViewModel(),
                ViewType.Buy => buyViewModel,
                ViewType.Sell => throw new NotImplementedException(),
                _ => null
            };
        }
    }
}
