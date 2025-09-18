using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.TransactionServices
{
    public class BuyStockService : IBuyStockService
    {
        private readonly IStockPriceService stockPriceService;
        private readonly IDataService<Account> accountService;

        public BuyStockService(IStockPriceService stockPriceService, IDataService<Account> accountService)
        {
            this.stockPriceService = stockPriceService;
            this.accountService = accountService;
        }

        public async Task<Account> BuyStock(Account buyer, string symbol, int shares)
        {
            double stockPrice = await stockPriceService.GetPrice(symbol);
            double transactionPrice = stockPrice * shares;

            if (transactionPrice > buyer.Balance) throw new InsufficientFundsException(buyer.Balance, transactionPrice);

            AssetTransaction trasaction = new()
            {
                Account = buyer,
                Asset = new()
                {
                    PricePerShare = stockPrice,
                    Symbol = symbol
                },
                DateProcessed = DateTime.Now,
                Shares = shares,
                IsPurchase = true
            };

            buyer.AssetTransactions.Add(trasaction);
            buyer.Balance -= stockPrice * shares;

            await accountService.Update(buyer.ID, buyer);

            return buyer;
        }
    }
}
