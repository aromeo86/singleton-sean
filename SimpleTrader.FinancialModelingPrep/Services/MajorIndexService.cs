using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public MajorIndexService()
        {
           
        }

        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            using FinancialModelingPrepHttpClient client = new();
            string uri = $"quote/{GetUriSuffix(indexType)}";
            MajorIndex index = await client.GetAsync<MajorIndex>(uri);
            index.Type = indexType;

            return index;
        }

        private string GetUriSuffix(MajorIndexType indexType)
        {
            return indexType switch
            {
                MajorIndexType.DowJones => ".DJI",
                MajorIndexType.Nasdaq => ".IXIC",
                MajorIndexType.SP500 => ".INX",
                _ => throw new Exception("MajorIndexType does not have a suffix defined")
            };
        }
    }
}
