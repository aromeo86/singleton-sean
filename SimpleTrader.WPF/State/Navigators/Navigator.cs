using SimpleTrader.WPF.Classes;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;
using System.Windows.Input;

namespace SimpleTrader.WPF.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel 
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            } 
        }

        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public Navigator(IRootSimpleTraderViewModelFactory viewModelFactory)
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, viewModelFactory);
        }
    }
}
