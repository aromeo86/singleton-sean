using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly FinancialModelingPrepHttpClientFactory httpClientFactory;

        public StockPriceService(FinancialModelingPrepHttpClientFactory httpClientFactory) => this.httpClientFactory = httpClientFactory;

        public async Task<double> GetPrice(string symbol)
        {
            using FinancialModelingPrepHttpClient client = new();
            string uri = $"stock/real-time-price/{symbol}";
            StockPriceResult price = await client.GetAsync<StockPriceResult>(uri);

            if (price.Price == 0) throw new InvalidSymbolException(symbol);

            return price.Price;
        }
    }
}
