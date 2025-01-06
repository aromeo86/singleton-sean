using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class BuyStockCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public BuyViewModel buyViewModel { get; set; }
        public IBuyStockService buyStockService { get; set; }

        public BuyStockCommand(BuyViewModel buyViewModel, IBuyStockService buyStockService)
        {
            this.buyViewModel = buyViewModel;
            this.buyStockService = buyStockService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                Account account = await buyStockService.BuyStock(new Account()
                {
                    ID = 1,
                    Balance = 500, 
                    AssetTransactions = []
                }, buyViewModel.Symbol, buyViewModel.SharesToBuy);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
