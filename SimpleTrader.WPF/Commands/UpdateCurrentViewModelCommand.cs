using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Factories;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly IRootSimpleTraderViewModelFactory viewModelFactory;
        private INavigator navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator, IRootSimpleTraderViewModelFactory viewModelFactory)
        {
            this.navigator = navigator;
            this.viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
                navigator.CurrentViewModel = viewModelFactory.CreateViewModel(viewType);
        }
    }
}
