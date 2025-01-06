namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClientFactory
    {
        private readonly string apiKey;

        public FinancialModelingPrepHttpClientFactory(string apiKey) => this.apiKey = apiKey;

        public FinancialModelingPrepHttpClient CreateHttpClient()
        {
            return new FinancialModelingPrepHttpClient();
        }
    }
}
